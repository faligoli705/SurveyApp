using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SurveyApp.DataAccessLayer.Contracts;
using SurveyApp.DataAccessLayer.Repositories;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture.Utilities;
using SurveyApp.Models;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AllowAnonymous]
    [Authorize(Roles = "admin")]

    public class OfferedAnswersController : BaseController
    {
        private readonly IOfferedAnswerRepository _offeredAnswerRepository;
        private readonly ILogger<OfferedAnswersController> _logger;


     /// <summary>
     /// 
     /// </summary>
     /// <param name="logger"></param>
        public OfferedAnswersController(IOfferedAnswerRepository offeredAnswerRepository, ILogger<OfferedAnswersController> logger)
        {
            this._offeredAnswerRepository = offeredAnswerRepository;
            this._logger = logger;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<OfferedAnswersDto>>> Get(CancellationToken cancellationToken)
        {
            var offeredAnswer = await _offeredAnswerRepository.TableNoTracking.ToListAsync(cancellationToken);
            return Ok(offeredAnswer);
        }

        [HttpPost]
        public virtual async Task<ApiResult<OfferedAnswers>> Create(OfferedAnswersDto offeredAnswersDto, CancellationToken cancellationToken)
        {
 
            _logger.LogError("متد Create فراخوانی شد");

            var offeredAnswers = new OfferedAnswers
            {
                OfferedAnswerText = offeredAnswersDto.OfferedAnswerText,
                IsDelete = false
            };
             
             await _offeredAnswerRepository.AddAsync(offeredAnswers, cancellationToken);
            return offeredAnswers;
        }

        [HttpPut]
        public virtual async Task<ApiResult> Update(int id, OfferedAnswers offeredAnswers, CancellationToken cancellationToken)
        {
            var updateOffered = await _offeredAnswerRepository.GetByIdAsync(cancellationToken, id);
            updateOffered.OfferedAnswerText = offeredAnswers.OfferedAnswerText;
            await _offeredAnswerRepository.UpdateAsync(updateOffered, cancellationToken);
            return Ok();

        }

        [HttpDelete]
        //[Authorize(Roles = "d9d82ea5-9155-eb11-9f34-8c736eabd2f2")]
        public virtual async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        {
            var offeredAnswer = await _offeredAnswerRepository.GetByIdAsync(cancellationToken, id);
            offeredAnswer.IsDelete = true;
            offeredAnswer.DeleteDate = DateTime.Now;
            await _offeredAnswerRepository.DeleteAsync(offeredAnswer, cancellationToken);
            return Ok();
        }

    }
}