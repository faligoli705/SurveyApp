using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Entities
{
   public class SurveyQuestionsAnswer: BaseEntities<Int32>
    {       
        public int UserId { get; set; }
        public int? QuestionId { get; set; }
        public int? OfferedAnswerId { get; set; }


        [ForeignKey(nameof(UserId))]
        public Users Users { get; set; }

        public Survey Survey { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public SurveyQuestions Questions { get; set; }

        [ForeignKey(nameof(OfferedAnswerId))]
        public OfferedAnswers OfferedAnswers { get; set; }


        public ICollection<Users> ChildUsers { get; set; }
        public ICollection<Survey> ChildSurvey { get; set; }
        public ICollection<SurveyQuestions> ChildQuestions { get; set; }
        public ICollection<OfferedAnswers> ChildOfferedAnswers { get; set; }
        public ICollection<SurveyCategory> ChlidSurveyCategory { get; set; }

    }
}
