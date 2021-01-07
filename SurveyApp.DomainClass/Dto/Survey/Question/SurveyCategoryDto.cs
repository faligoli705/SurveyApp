using SurveyApp.DomainClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Dto
{
    public class SurveyCategoryDto :BaseEntities<Int32>
    {
        public Guid UserId { get; set; }
        public string NameCategory { get; set; }
        public string SubNameCategory { get; set; }
    }
}
