using SurveyApp.DomainClass.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Dto
{
    public class SurveyQuestionsAnswerDto : BaseEntities
    {
        public Guid UserId { get; set; }
        public int SurveyId { get; set; }
        public int QuestionId { get; set; }
        public int OfferedAnswerId { get; set; }

        public UsersDto Users { get; set; }

        public SurveyDto Survey { get; set; }

        public QuestionsDto Questions { get; set; }

        public OfferedAnswersDto OfferedAnswers { get; set; }

        public ICollection<UsersDto> ChildUsersDto { get; set; }
        public ICollection<SurveyDto> ChildSurveyDto { get; set; }
        public ICollection<QuestionsDto> ChildQuestionsDto { get; set; }
        public ICollection<OfferedAnswersDto> ChildOfferedAnswersDto { get; set; }
    }
}
