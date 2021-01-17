using SurveyApp.DomainClass.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.DataAccessLayer
{
    public interface IAuthenRepository
    {
        Task<Users> ListUserLogin(string userName, string userPassword);
    }
}