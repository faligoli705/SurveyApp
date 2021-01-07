using SurveyApp.DomainClass.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Entities
{
    public class SurveyCategory :BaseEntities
    {
        public Guid UserId { get; set; }
        [MaxLength(100)]
        public string NameCategory { get; set; }
        [MaxLength(100)]
        public string SubNameCategory { get; set; }
    }
}
