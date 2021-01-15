using SurveyApp.DomainClass.Entities;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSurveyApp.Models
{
    public class SurveyQuestionsDto : BaseDto<SurveyQuestionsDto, SurveyQuestions,Int32>,IEntity<Int32>
    {
        public Int32 SurveyId { get; set; }
        public Guid RoleId { get; set; }

        public string QuestionText { get; set; }
        public DateTime? QuestionExpiresOnDate { get; set; } //انقضا
        public DateTime? PublishedDate { get; set; }
    }
}
