using SurveyApp.DomainClass.Entities;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSurveyApp.Models
{/// <summary>
/// 
/// </summary>
    public class UserDto
    { 
        public string UserName { get; set; } 
        public string UserPassword{ get; set; }
         
    }
}
