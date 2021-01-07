using SurveyApp.DomainClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Dto
{
    public class RolesDto : BaseEntities<Guid>
    {
    
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
