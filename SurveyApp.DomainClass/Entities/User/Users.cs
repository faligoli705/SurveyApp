using Microsoft.AspNetCore.Identity;
using SurveyApp.DomainClass.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Entities
{
    public class Users : IdentityUser<Guid>
    {
        public Users()
        {
            IsActive = true;
        }
        public Guid RoleId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LName { get; set; }
        public GenderType Gender { get; set; }
        public EmailAddressAttribute Email { get; set; }
        [Required]
        [MaxLength(500)]
        public string UserPasswordHash { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Roles Roles { get; set; }
        public ICollection<Questions> ChildQuestions { get; set; }
        public ICollection<OfferedAnswers> ChildOfferedAnswers { get; set; }
    }
    public enum GenderType
    {
        [Display(Name = "خانم")]
        Femel = 1,

        [Display(Name = "آقا")]
        Male = 2
    }
}
