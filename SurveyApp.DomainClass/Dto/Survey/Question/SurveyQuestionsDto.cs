using SurveyApp.DomainClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Dto
{
    public class SurveyQuestionsDto : BaseEntities<Int32>
    {
        public Guid UserId { get; set; }
        public int SurveyId { get; set; }
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }


         public UsersDto Users { get; set; }

         public SurveyDto Survey { get; set; }

         public QuestionsDto Questions { get; set; }
         public SurveyCategoryDto Category { get; set; }

        public ICollection<UsersDto> ChildUsersDto { get; set; }
        public ICollection<SurveyDto> ChildSurveyDto { get; set; }
        public ICollection<QuestionsDto> ChlidQuestionsDto { get; set; }
        public ICollection<SurveyCategoryDto> ChlidSurveyCategoryDto { get; set; }

    }
}
