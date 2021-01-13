using SurveyApp.DomainClass.Entities;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class SurveyAnswerDto : BaseDto<SurveyAnswerDto, SurveyAnswer>, IEntity
    {
        public Guid UserId { get; set; }
        public int? QuestionId { get; set; }
        public int? OfferedAnswerId { get; set; }
        public string OtherText { get; set; }
    }
}
