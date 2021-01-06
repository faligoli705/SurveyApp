using SurveyApp.DomainClass.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Dto
{
    public class SurveyDto : BaseEntities
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsOpen { get; set; }
    }
}
