using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.DomainClass.Entities
{
    public class Users :  IdentityUser<Guid>, IEntity<Guid>
    {
        public Users()
        {
            IsActive = true;
            //SecurityStamp = Guid.NewGuid();
        }
        public Guid RoleId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LName { get; set; }
        public GenderType Gender { get; set; } 
        public DateTimeOffset? LastLoginDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDelete { get; set; }
        //public Guid SecurityStamp { get; set; }
        public bool IsActive { get; set; }

        public ICollection<SurveyQuestions> ChildQuestions { get; set; }
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
