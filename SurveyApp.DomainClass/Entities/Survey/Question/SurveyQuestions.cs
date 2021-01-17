using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Entities
{
   public class SurveyQuestions: BaseEntities<Int32>,IEntity<Int32>
    {
        public Int32 SurveyId { get; set; }
        public int? RoleId { get; set; }
        public int? UsersId { get; set; }
        [Required]
        [MaxLength(300)]
        public string QuestionText { get; set; }
        public DateTime? QuestionExpiresOnDate { get; set; } //انقضا
        public DateTime? PublishedDate { get; set; }


        public Survey Survey { get; set; }
        public Users Users { get; set; }
        [ForeignKey(nameof(SurveyId))]
        public ICollection<Survey> ChildSurvey { get; set; }
        [ForeignKey(nameof(RoleId))]

        public ICollection<Roles> ChildRoles { get; set; }
    }
}
