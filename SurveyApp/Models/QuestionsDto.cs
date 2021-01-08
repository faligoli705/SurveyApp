using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class QuestionsDto
    {
        public string QuestionText { get; set; }
        public DateTime? QuestionExpiresOnDate { get; set; } //انقضا
        public DateTime? PublishedDate { get; set; }
    }
}
