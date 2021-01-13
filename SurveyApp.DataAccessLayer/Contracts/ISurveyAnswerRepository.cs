using SurveyApp.DataAccessLayer.Contracts;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.DataAccessLayer.Repositories
{
    public interface ISurveyAnswerRepository : IBaseRepository<SurveyAnswer>, IScopedDependency
    {
        Task AddAsync(SurveyAnswer surveyAnswer, CancellationToken cancellationToken);
    }
}