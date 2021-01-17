using AutoMapper;
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
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] 
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

        [HttpGet]
        public virtual async Task<ActionResult<List<SurveyCategoryDto>>> Get(CancellationToken cancellationToken)
        {
             var categories = await _categoyRepository.TableNoTracking.ToListAsync(cancellationToken);
            return Ok(categories);
        }


        [HttpPost]
         public virtual async Task<ApiResult<SurveyCategory>> Create(SurveyCategoryDto categoryDto, CancellationToken cancellationToken)
        {
            _logger.LogError("متد Create فراخوانی شد");
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
         public virtual async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        {
            var category = await _categoyRepository.GetByIdAsync(cancellationToken, id);
            category.IsDelete = true;
            category.DeleteDate = DateTime.Now;
            await _categoyRepository.DeleteAsync(category, cancellationToken);
            return Ok();
        }

    }
}