using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SurveyApp.DataAccessLayer.Contracts;
using SurveyApp.DataAccessLayer.Repositories;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Models;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    //[Authorize]

    public class QuestionController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        
        private readonly IQuestionRepository _questionRepository;

        private readonly ILogger<QuestionController> _logger;

        public QuestionController(IQuestionRepository questionRepository, ILogger<QuestionController> logger)
        {
            this._questionRepository = questionRepository;
            this._logger = logger;
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public virtual async Task<ApiResult<SurveyQuestions>> Create(QuestionsDto questionDto, CancellationToken cancellationToken)
        //{
        //    _logger.LogError("متد Create فراخوانی شد");

        //    var exists = await _questionRepository.TableNoTracking.AnyAsync(p => p.QuestionText == questionDto.QuestionText);
        //    if (exists)
        //        return BadRequest("نام کاربری تکراری است");


        //    var question = new SurveyQuestions
        //    {
        //        QuestionText = questionDto.QuestionText,
        //        SurveyId = ,
        //        Gender = questionDto.Gender,
        //        RoleId = questionDto.RoleId,
        //        UserName = questionDto.UserName,
        //        Email = questionDto.EmailUser



        //    };
        //    //var result = await userManager.CreateAsync(user, userDto.UserPassword);
        //    var result = await userManager.CreateAsync(user, userDto.UserPassword);
        //    var result2 = await roleManager.CreateAsync(new Roles
        //    {
        //        Name = "Admin",
        //        Description = "admin role"
        //    });

        //    //var result3 = await userManager.AddToRoleAsync(user, "Admin");

        //    //await userRepository.AddAsync(user, userDto.Password, cancellationToken);
        //    return user;
        //}

        //[HttpPut]
        //[AllowAnonymous]
        //public virtual async Task<ApiResult> Update(int id, SurveyQuestions question, CancellationToken cancellationToken)
        //{
        //    //var updateUser = await questionRepository.GetByIdAsync(cancellationToken, id);

        //    //updateUser.UserName = user.UserName;
        //    //updateUser.PasswordHash = user.PasswordHash;
        //    //updateUser.FName = user.FName;
        //    //updateUser.LName = user.LName;
        //    //updateUser.Gender = user.Gender;
        //    //updateUser.IsActive = user.IsActive;
        //    //updateUser.LastLoginDate = user.LastLoginDate;

        //    //await userRepository.UpdateAsync(updateUser, cancellationToken);

        //    //return Ok();
        //}

    }
}