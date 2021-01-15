using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SurveyApp.Infrastucture.Execptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebSurveyApp.Models;

namespace WebSurveyApp.Service
{
    public class UserRepository : IUserRepository
    {
        string _apiUrl = "https://localhost:44357/api/User";
        HttpClient _httpClient;
        IHttpClientFactory _httpClientFactory;
        ILogger<UserRepository> _logger;

        public UserRepository(HttpClient httpClient,ILogger<UserRepository> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public List<UserDto> GetAllUser(string token, string userName)
        {
            try
            {
                _logger.LogWarning("اجرای متد گرفتن همه کاربرها");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = _httpClient.GetStringAsync(_apiUrl).Result;
                List<UserDto> list = JsonConvert.DeserializeObject<List<UserDto>>(result);
                return list;
            }
            catch (Exception)
            {

                throw new BadRequestException("کاستومر با خطا مواجه شد");

            } 
        }

        public UserDto GetUserById(int userId)
        {
            var result = _httpClient.GetStringAsync(_apiUrl + "/" + userId).Result;
            UserDto userDto = JsonConvert.DeserializeObject<UserDto>(result);
            return userDto;

        }

        public void AddUser(UserDto userDto)
        {
            string jsonUser = JsonConvert.SerializeObject(userDto);
            StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            var result = _httpClient.PostAsync(_apiUrl, content).Result;
        }

        public void UpdateUser(UserDto userDto)
        {

            string jsonUser = JsonConvert.SerializeObject(userDto);
            StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            var result = _httpClient.PutAsync(_apiUrl, content).Result;
        }

        public void DeleteUser(int userId)
        {
            var result = _httpClient.DeleteAsync(_apiUrl + "/" + userId).Result;
        }
    }



}
