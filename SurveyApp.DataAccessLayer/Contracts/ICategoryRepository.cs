using SurveyApp.DataAccessLayer.Contracts;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.DataAccessLayer.Repositories
{
    public interface ICategoryRepository : IBaseRepository<SurveyCategory>, IScopedDependency
    {
        Task AddAsync(SurveyCategory surveyCategory, CancellationToken cancellationToken);
    }
}