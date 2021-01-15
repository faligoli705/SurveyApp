using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SurveyApp.DataAccessLayer.Contracts;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture.Execptions;
using SurveyApp.Infrastucture.Utilities;
using SurveyApp.Models;
using SurveyApp.Services;
using SurveyApp.WebFramework.Api;
using TokenRequest = SurveyApp.Models.TokenRequest;

namespace SurveyApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    //[AllowAnonymous]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        private readonly IJwtService _jwtService;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<Roles> _roleManager;
        private readonly SignInManager<Users> _signInManager;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="logger"></param>
        /// <param name="jwtService"></param>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="signInManager"></param>
        public UserController(IUserRepository userRepository, ILogger<UserController> logger, IJwtService jwtService,
       UserManager<Users> userManager, RoleManager<Roles> roleManager, SignInManager<Users> signInManager)
        {
            this._userRepository = userRepository;
            this._logger = logger;
            this._jwtService = jwtService;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }



        [HttpGet]
        //[Authorize(Roles = "9f998266-8455-eb11-9f34-8c736eabd2f2")]
        public virtual async Task<ActionResult<List<Users>>> Get(CancellationToken cancellationToken)
        {
            //var userName = HttpContext.User.Identity.GetUserName();
            //userName = HttpContext.User.Identity.Name;
            //var userId = HttpContext.User.Identity.GetUserId();
            //var userIdInt = HttpContext.User.Identity.GetUserId<int>();
            //var phone = HttpContext.User.Identity.FindFirstValue(ClaimTypes.MobilePhone);
            //var role = HttpContext.User.Identity.FindFirstValue(ClaimTypes.Role);

            var users = await _userRepository.TableNoTracking.ToListAsync(cancellationToken);
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        //[Authorize(Roles = "9f998266-8455-eb11-9f34-8c736eabd2f2")]
        public virtual async Task<ApiResult<Users>> Get(int id, CancellationToken cancellationToken)
        {
            var user2 = await _userManager.FindByIdAsync(id.ToString());
            var role = await _roleManager.FindByNameAsync("Admin");

            var user = await _userRepository.GetByIdAsync(cancellationToken, id);
            if (user == null)
                return NotFound();

            await _userManager.UpdateSecurityStampAsync(user);
            //await userRepository.UpdateSecurityStampAsync(user, cancellationToken);

            return user;
        }

        /// <summary>
        /// This method generate JWT Token
        /// </summary>
        /// <param name="tokenRequest">The information of token request</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [AllowAnonymous]
        public virtual async Task<ActionResult> Token([FromForm] TokenRequest tokenRequest, CancellationToken cancellationToken)
        {
            _logger.LogError("متد Token فراخوانی شد");


            if (!tokenRequest.grant_type.Equals("password", StringComparison.OrdinalIgnoreCase))
                throw new Exception("OAuth flow is not password.");

            var user1 = await _userRepository.GetByUserAndPass(tokenRequest.username, tokenRequest.password, cancellationToken);
            var user = await _userManager.FindByNameAsync(tokenRequest.username);
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, tokenRequest.password);

            //if (user1 == null)
            //    throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");
            if (user == null)
                throw new BadRequestException("نام کاربری یافت نشد");
            if (!isPasswordValid)
                throw new BadRequestException("پسورد وارد شده اشتباه است");

            var jwt = await _jwtService.GenerateAsync(user);
            return new JsonResult(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public virtual async Task<ApiResult<Users>> Create(UserDto userDto, CancellationToken cancellationToken)
        {
            _logger.LogError("متد Create فراخوانی شد");

            var exists = await _userRepository.TableNoTracking.AnyAsync(p => p.UserName == userDto.UserName);
            if (exists)
                return BadRequest("نام کاربری تکراری است");

            var user = new Users
            {
                Id = Guid.NewGuid(),
                FName = userDto.FName,
                LName = userDto.LName,
                Gender = userDto.Gender,
                RoleId = userDto.RoleId,                         //سطح دسترسی توسط ادمین مشخص میشود بصورت پیش فرض کاربر عادی
                UserName = userDto.UserName,
                Email = userDto.EmailUser,
                CreateDate = DateTime.Now
            };
            var result = await _userManager.CreateAsync(user, userDto.UserPassword);
            //var result2 = await _roleManager.CreateAsync(new Roles
            //{
            //    Name = "Admin",
            //    Description = "admin role"
            //});

            var result3 = await _userManager.AddToRoleAsync(user, userDto.UserPassword);
            await _userRepository.AddAsync(user, userDto.UserPassword, cancellationToken);
            return user;
        }

        [HttpPut]
        [Authorize]
        public virtual async Task<ApiResult> Update(int id, Users user, CancellationToken cancellationToken)
        {
            var updateUser = await _userRepository.GetByIdAsync(cancellationToken, id);

            updateUser.RoleId = user.RoleId;
            updateUser.UserName = user.UserName;
            updateUser.PasswordHash = user.PasswordHash;
            updateUser.FName = user.FName;
            updateUser.LName = user.LName;
            updateUser.Gender = user.Gender;
            updateUser.IsActive = user.IsActive;
            updateUser.LastLoginDate = user.LastLoginDate;

            await _userRepository.UpdateAsync(updateUser, cancellationToken);

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "9f998266-8455-eb11-9f34-8c736eabd2f2")]

        public virtual async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(cancellationToken, id);
            user.IsDelete = true;
            user.DeleteDate = DateTime.Now;
            await _userRepository.DeleteAsync(user, cancellationToken);
            return Ok();
        }

    }
}
