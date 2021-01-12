using SurveyApp.DataAccessLayer.Contracts;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.DataAccessLayer.Repositories
{
    public interface IQuestionRepository : IBaseRepository<SurveyQuestions>,IScopedDependency
    {
        Task AddAsync(SurveyQuestions surveyQuestion, string password, CancellationToken cancellationToken);
    }
}