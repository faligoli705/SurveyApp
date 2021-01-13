﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Entities
{
   public class SurveyAnswer: BaseEntities<Int32>, IEntity<Int32>
    {
        public Guid UserId { get; set; }
        public int? QuestionId { get; set; }
        public int? OfferedAnswerId { get; set; }
        [MaxLength(300)]
        public string OtherText { get; set; }


        [ForeignKey(nameof(UserId))]
        public Users Users { get; set; }
         

        [ForeignKey(nameof(QuestionId))]
        public SurveyQuestions Questions { get; set; }

        [ForeignKey(nameof(OfferedAnswerId))]
        public OfferedAnswers OfferedAnswers { get; set; }

        public ICollection<Users> ChildUsers { get; set; }
        public ICollection<Survey> ChildSurveys { get; set; }
        public ICollection<SurveyQuestions> ChildQuestions { get; set; }
        public ICollection<OfferedAnswers> ChildOfferedAnswers { get; set; }
    }
}
