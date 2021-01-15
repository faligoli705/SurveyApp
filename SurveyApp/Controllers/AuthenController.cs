
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SurveyApp.DataAccessLayer;
using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[Controller]")]
    [ApiController]

    public class AuthenController : Controller
    {
        private readonly ILogger<AuthenController> _logger;

        private readonly IAuthenRepository _authen;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authen"></param>
        public AuthenController(IAuthenRepository authen, ILogger<AuthenController> logger)
        {
            _authen = authen;
            _logger = logger;
        }
        /// <summary>
        /// لاگین شدن و اعتبار سنجی کاربر
        /// </summary>
        /// <param></param>
        /// <returns></returns>
         [HttpPost]
         [AllowAnonymous]
        public IActionResult PostLogin(LoginDto login)
        {

            _logger.LogInformation("متد Login فراخوانی شد");

            var userName = login.UserName;
            var userPassword = login.UserPassword;
            if (!ModelState.IsValid)
            {
                _logger.LogError("The Model is not valid");
                return BadRequest("The Model is not valid");
            }

            var user = _authen.ListcustomersLogin(userName, userPassword);
            if (user == null)
            {
                _logger.LogError("نام کاربری یا رمز عبور اشتباه است یا کاربر وجود ندارد");
                return BadRequest("Not exist user");
            }
            if (login.UserPassword != user.UserName || login.UserPassword != user.PasswordHash)
            {
                _logger.LogError("نام کاربری یا رمز اشتباه است");
                return Unauthorized();
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("LongerThan-16Char-SecretKey"));
            var signinCredintioals = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOption = new JwtSecurityToken(
                issuer: "https://localhost:44357",
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.Name,login.UserName),
                    //new Claim(ClaimTypes.Name,login.FName),
                    new Claim(ClaimTypes.Role,"Admin")
                },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredintioals
                );
            _logger.LogInformation("توکن ایجاد شد");
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
            return Ok(new { token = tokenString });
        }
    }
}
