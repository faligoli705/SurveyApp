using SurveyApp.DomainClass.Entities;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class QuestionsDto : BaseDto<QuestionsDto, Questions,Int32>,IEntity<Int32>
    {
        public string QuestionText { get; set; }
        public DateTime? QuestionExpiresOnDate { get; set; } //انقضا
        public DateTime? PublishedDate { get; set; }
    }
}
