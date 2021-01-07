using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.DomainClass.Entities
{
   public class Roles: IdentityRole<Guid>
    {
        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
    public class RoleConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.Property(p => p.RoleName).IsRequired().HasMaxLength(50);
        }
    }
}
