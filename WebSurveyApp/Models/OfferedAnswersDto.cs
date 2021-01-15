using SurveyApp.DomainClass.Entities;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSurveyApp.Models
{
    public class OfferedAnswersDto : BaseDto<OfferedAnswersDto, OfferedAnswers>
    {
        public string OfferedAnswerText { get; set; }

    }
}
