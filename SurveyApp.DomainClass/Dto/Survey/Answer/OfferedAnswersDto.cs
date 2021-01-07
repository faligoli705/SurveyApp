using SurveyApp.DomainClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Dto
{ 
    public class OfferedAnswersDto : BaseEntities<Int32>
    {
        public string OfferedAnswerText { get; set; }
    }
}
