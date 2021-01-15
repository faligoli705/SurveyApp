using System.Collections.Generic;
using WebSurveyApp.Models;

namespace WebSurveyApp.Service
{
    public interface IUserRepository
    {
        void AddUser(UserDto userDto);
        void DeleteUser(int userId);
        List<UserDto> GetAllUser(string token, string userName);
        UserDto GetUserById(int userId);
        void UpdateUser(UserDto userDto);
    }
}