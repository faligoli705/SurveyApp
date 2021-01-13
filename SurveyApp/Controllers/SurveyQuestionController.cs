﻿using AutoMapper;
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
    //[AllowAnonymous]
    [Authorize(Roles = "d9d82ea5-9155-eb11-9f34-8c736eabd2f2")] //persone


    public class SurveyQuestionController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>

        private readonly IQuestionRepository _questionRepository;

        private readonly ILogger<SurveyQuestionController> _logger;

        public SurveyQuestionController(IQuestionRepository questionRepository, ILogger<SurveyQuestionController> logger)
        {
            this._questionRepository = questionRepository;
            this._logger = logger;
        }

        [HttpPost]
        public virtual async Task<ApiResult<SurveyQuestions>> Create(SurveyQuestionsDto questionDto, CancellationToken cancellationToken)
        {
            _logger.LogError("متد Create فراخوانی شد");
            //var allowedToAskQuestions = await _questionRepository.TableNoTracking.AnyAsync(p => p.RoleId == questionDto.QuestionText);
            //if (exists)
            //    return BadRequest("نام کاربری تکراری است");

            var exists = await _questionRepository.TableNoTracking.AnyAsync(p => p.QuestionText == questionDto.QuestionText);
            if (exists)
                return BadRequest("نام کاربری تکراری است");


            var question = new SurveyQuestions
            {
                QuestionText = questionDto.QuestionText,
                SurveyId = questionDto.SurveyId,
                QuestionExpiresOnDate = questionDto.QuestionExpiresOnDate,
                PublishedDate = questionDto.PublishedDate,
                IsDelete = false
            };
            await _questionRepository.AddAsync(question, cancellationToken);
            return question;
        }

        [HttpPut]
        public virtual async Task<ApiResult> Update(int id, SurveyQuestions question, CancellationToken cancellationToken)
        {
            var updateQuestion = await _questionRepository.GetByIdAsync(cancellationToken, id);

            updateQuestion.QuestionText = question.QuestionText;
            updateQuestion.SurveyId = question.SurveyId;
            updateQuestion.QuestionExpiresOnDate = question.QuestionExpiresOnDate;
            updateQuestion.PublishedDate = question.PublishedDate;

            await _questionRepository.UpdateAsync(updateQuestion, cancellationToken);

            return Ok();
        }

    }
}