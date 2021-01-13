using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SurveyApp.DataAccessLayer.Repositories;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture.Utilities;
using SurveyApp.Models;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    //[Authorize]

    public class SurveyAnswerController : BaseController
    {
        private readonly ISurveyAnswerRepository _surveyAnswerRepository;
        private readonly ILogger<SurveyAnswerController> _logger;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public SurveyAnswerController(ISurveyAnswerRepository surveyAnswerRepository, ILogger<SurveyAnswerController> logger)
        {
            this._surveyAnswerRepository = surveyAnswerRepository;
            this._logger = logger;
        }


        [HttpPost]
        [Authorize]
        public virtual async Task<ApiResult<SurveyAnswer>> Create(SurveyAnswerDto surveyAnswerDto, CancellationToken cancellationToken)
        {
            _logger.LogError("متد Create فراخوانی شد");
            var userId = HttpContext.User.Identity.GetUserId();

            var surveyAnswer = new SurveyAnswer
            {
                //UserId = strUserId ,
                QuestionId = surveyAnswerDto.QuestionId,
                OfferedAnswerId = surveyAnswerDto.OfferedAnswerId,
                OtherText = surveyAnswerDto.OtherText,
                IsDelete = false
            };

            await _surveyAnswerRepository.AddAsync(surveyAnswer, cancellationToken);
            return surveyAnswer;
        }

        [HttpPut]
        [Authorize]
        public virtual async Task<ApiResult> Update(int id, SurveyAnswer surveyAnswer, CancellationToken cancellationToken)
        {
            var exists = await _surveyAnswerRepository.TableNoTracking.AnyAsync(p => p.UserId == surveyAnswer.UserId
                                                                                && p.QuestionId == surveyAnswer.QuestionId);
            if (exists)
                return BadRequest("شما قبلا به این سوال پاسخ دادید");


            var updateSurveyAnswer = await _surveyAnswerRepository.GetByIdAsync(cancellationToken, id);
            updateSurveyAnswer.OtherText = updateSurveyAnswer.OtherText;
            updateSurveyAnswer.OfferedAnswerId = updateSurveyAnswer.OfferedAnswerId;
            updateSurveyAnswer.UpdateDate = DateTime.Now;
            await _surveyAnswerRepository.UpdateAsync(updateSurveyAnswer, cancellationToken);
            return Ok();

        }

        [HttpDelete]
        [Authorize(Roles = "d9d82ea5-9155-eb11-9f34-8c736eabd2f2")] //persone
        public virtual async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        {
            var offeredAnswer = await _surveyAnswerRepository.GetByIdAsync(cancellationToken, id);
            offeredAnswer.IsDelete = true;
            offeredAnswer.DeleteDate = DateTime.Now;
            await _surveyAnswerRepository.DeleteAsync(offeredAnswer, cancellationToken);
            return Ok();
        }

    }
}