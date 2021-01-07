using SurveyApp.DomainClass.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Dto
{
    public class UsersDto : BaseEntities<Guid>
    {
        public UsersDto()
        {
            IsActive = true;
        }
        public Guid RoleId { get; set; }
        public string FName { get; set; } 
        public string LName { get; set; }
        public GenderType Gender { get; set; }
        public EmailAddressAttribute Email { get; set; }
        public string UserPasswordHash { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public bool IsActive { get; set; }

        public RolesDto Roles { get; set; }
        public ICollection<QuestionsDto> ChildQuestionsDto { get; set; }
        public ICollection<OfferedAnswersDto> ChildOfferedAnswersDto { get; set; }
    }
    public enum GenderType
    {
        [Display(Name = "خانم")]
        Femel = 1,

        [Display(Name = "آقا")]
        Male = 2
    }
}
