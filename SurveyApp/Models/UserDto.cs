using SurveyApp.DomainClass.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class UserDto :IValidatableObject
    {
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        public GenderType Gender { get; set; }
        [Required]
        public string EmailUser { get; set; }
        [Required]
        public string UserPassword{ get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            if (UserPassword.Equals("123456"))
                yield return new ValidationResult("رمز عبور نمیتواند 123456 باشد", new[] { nameof(UserPassword) });
        }
    }
}
