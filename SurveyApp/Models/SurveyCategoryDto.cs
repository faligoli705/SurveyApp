using SurveyApp.DomainClass.Entities;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class SurveyCategoryDto : BaseDto<SurveyCategoryDto, SurveyCategory,Int32>
    {
        public int Pid { get; set; }
        public string NameCategory { get; set; }
        public string SubNameCategory { get; set; }
    }

    public class SurveyCategorySelectDto : BaseDto<SurveyCategorySelectDto, SurveyCategory, Int32>
    {
        public string NameCategory { get; set; }
    }
}
