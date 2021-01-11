using SurveyApp.DomainClass.Entities;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class CategoryDto : BaseDto<CategoryDto, SurveyCategory, Int32>, IEntity<Int32>
    {
        public string NameCategory { get; set; }
        public string SubNameCategory { get; set; }
    }
}
