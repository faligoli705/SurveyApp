using SurveyApp.DomainClass.Entities;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public interface IJwtService
    {
        Task<AccessToken> GenerateAsync(Users user);
    }
}