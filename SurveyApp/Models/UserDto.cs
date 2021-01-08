using SurveyApp.DomainClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class UserDto
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public GenderType Gender { get; set; }
        public string EmailUser { get; set; }
        public string UserPassword{ get; set; }

    }
}
