using SurveyApp.DomainClass.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Entities
{
   public class Survey : BaseEntities
    {
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool IsOpen { get; set; }
    }
}
