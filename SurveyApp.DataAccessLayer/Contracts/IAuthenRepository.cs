using SurveyApp.DomainClass.Entities;

namespace SurveyApp.DataAccessLayer
{
    public interface IAuthenRepository
    {
        Users ListcustomersLogin(string userName, string userPassword);
    }
}