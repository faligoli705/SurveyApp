using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SurveyApp.DataAccessLayer.Contracts;
using SurveyApp.DataAccessLayer.Repositories;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture.Utilities;
using SurveyApp.Models;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[AllowAnonymous]
    public class CategoryController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>

        ILogger<CategoryController> _logger;
        ICategoryRepository _categoyRepository;
        public CategoryController(ICategoryRepository categoyRepository, ILogger<CategoryController> logger)
        {
            this._categoyRepository = categoyRepository;
            this._logger = logger;
        }


        [HttpPost]
        [Authorize(Roles ="d9d82ea5-9155-eb11-9f34-8c736eabd2f2")] //persone

        public virtual async Task<ApiResult<SurveyCategory>> Create(SurveyCategoryDto categoryDto, CancellationToken cancellationToken)
        {
            _logger.LogError("متد Create فراخوانی شد");
            var userId = HttpContext.User.Identity.GetUserId();

            var category = new SurveyCategory
            {
                //UserId = Convert.ToInt32(userId),
                Pid=categoryDto.Pid,
                SubNameCategory=categoryDto.SubNameCategory,
                IsDelete = false
            };

            await _categoyRepository.AddAsync(category, cancellationToken);
            return category;
        }

        [HttpPut]
        [Authorize(Roles = "d9d82ea5-9155-eb11-9f34-8c736eabd2f2")]
        public virtual async Task<ApiResult> Update(int id, SurveyCategory surveyCategory, CancellationToken cancellationToken)
        {

            var updateCategory = await _categoyRepository.GetByIdAsync(cancellationToken, id);
            updateCategory.SubNameCategory = surveyCategory.SubNameCategory;
            updateCategory.Pid = surveyCategory.Pid;
            updateCategory.NameCategory = surveyCategory.NameCategory;
            await _categoyRepository.UpdateAsync(updateCategory, cancellationToken);
            return Ok();

        }

        [HttpDelete]
        [Authorize(Roles = "d9d82ea5-9155-eb11-9f34-8c736eabd2f2")]
        public virtual async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        {
            var offeredAnswer = await _categoyRepository.GetByIdAsync(cancellationToken, id);
            offeredAnswer.IsDelete = true;
            offeredAnswer.DeleteDate = DateTime.Now;
            await _categoyRepository.DeleteAsync(offeredAnswer, cancellationToken);
            return Ok();
        }

    }
}