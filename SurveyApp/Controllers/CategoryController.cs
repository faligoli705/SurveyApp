using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataAccessLayer.Contracts;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Models;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
   
    public class CategoyController : CrudController<CategoryDto, SurveyCategory>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public CategoyController(IBaseRepository<SurveyCategory> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}