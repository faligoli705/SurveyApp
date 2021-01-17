﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Entities
{
    public class OfferedAnswers : BaseEntities<Int32>,IEntity<Int32>
    {
        [MaxLength(300)]
        public string OfferedAnswerText { get; set; }
        public Int32 SurveyQuestionsAnswerId { get; set; }


    }
}
