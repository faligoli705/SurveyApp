using SurveyApp.DomainClass.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Entities
{
    public class OfferedAnswers : BaseEntities
    {
        [StringLength(300)]
        public string OfferedAnswerText { get; set; }


    }
}
