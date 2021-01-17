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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]


    public class SurveyController : CrudController<SurveyDto, Survey>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public SurveyController(IBaseRepository<Survey> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

    }
}