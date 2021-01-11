using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public interface IJwtService : IScopedDependency
    {
        Task<AccessToken> GenerateAsync(Users user);
    }
}