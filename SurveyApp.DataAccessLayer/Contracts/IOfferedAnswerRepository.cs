using SurveyApp.DataAccessLayer.Contracts;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.DataAccessLayer.Repositories
{
    public interface IOfferedAnswerRepository : IBaseRepository<OfferedAnswers>, IScopedDependency
    {
        Task AddAsync(OfferedAnswers offeredAnswers, CancellationToken cancellationToken);
        Task DeleteAsync(OfferedAnswers offeredAnswers, CancellationToken cancellationToken);
    }
}