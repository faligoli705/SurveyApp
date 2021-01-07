using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public EmailAddressAttribute EmailUser { get; set; }
        [Required]
        [MaxLength(500)]
        public string UserPasswordHash { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Questions> ChildQuestions { get; set; }
    }

    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);
        }
    }

    public enum GenderType
    {
        [Display(Name = "خانم")]
        Femel = 1,

        [Display(Name = "آقا")]
        Male = 2
    }
}
