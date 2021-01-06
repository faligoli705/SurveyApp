using SurveyApp.DomainClass.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Entities
{
   public class Roles: BaseEntities<Guid>
    {
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
