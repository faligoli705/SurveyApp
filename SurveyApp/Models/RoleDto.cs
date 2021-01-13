using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyApp.DomainClass.Entities;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class RoleDto : IdentityRole<string>, IEntity<string>
    {
        public string Description { get; set; }

        public class RoleConfiguration : IEntityTypeConfiguration<Roles>
        {
            public void Configure(EntityTypeBuilder<Roles> builder)
            {
                builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            }
        }
    }
}
