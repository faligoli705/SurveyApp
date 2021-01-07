using SurveyApp.DomainClass.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Entities
{
   public class Roles: BaseEntities
    {
        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
