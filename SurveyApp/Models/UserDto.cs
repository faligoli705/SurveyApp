using SurveyApp.DomainClass.Entities;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Models
{/// <summary>
/// 
/// </summary>
    public class UserDto : BaseDto<UserDto, Users, Guid>, IValidatableObject
    {
        public Guid RoleId { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }

        public string UserName { get; set; }
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
