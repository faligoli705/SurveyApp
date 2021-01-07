using SurveyApp.DomainClass.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Entities
{
   public class SurveyQuestions : BaseEntities
    {        
        public Guid UserId { get; set; }
        public int SurveyId { get; set; }
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }


        [ForeignKey(nameof(UserId))]
        public Users Users { get; set; }

        [ForeignKey(nameof(SurveyId))]
        public Survey Survey { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public Questions Questions { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public SurveyCategory Category { get; set; }

        public ICollection<Users> ChildUsers { get; set; }
        public ICollection<Survey> ChildSurvey { get; set; }
        public ICollection<Questions> ChlidQuestions { get; set; }
        public ICollection<SurveyCategory> ChlidSurveyCategory { get; set; }

    }
}
