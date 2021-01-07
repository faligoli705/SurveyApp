using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DomainClass.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UsersController()
        {
            return View();
        }
    }
}
