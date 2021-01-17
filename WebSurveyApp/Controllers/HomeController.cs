using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SurveyApp.Infrastucture.Utilities;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using WebSurveyApp.Models;
using WebSurveyApp.Service;

namespace WebSurveyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userrepository;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClient;

        public HomeController(IUserRepository userRepository, IHttpClientFactory httpClient, ILogger<HomeController> logger)
        {
            _userrepository = userRepository;
            _httpClient = httpClient;
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Login(UserDto login)
        {
            if (!ModelState.IsValid)
                return View();
            var client = _httpClient.CreateClient("ClientSurveyApp");
            var jsonBody = JsonConvert.SerializeObject(login);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
 
            var response = client.PostAsync("/Api/Authen", content).Result;

            var receiveStream = response.Content.ReadAsStringAsync().Result.Split("\"")[1].Split("\"")[0];

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(receiveStream);
            var tokenS = handler.ReadToken(receiveStream) as JwtSecurityToken;
            var tokensss = tokenS.Claims as List<Claim>; 
            if (response.IsSuccessStatusCode)
            {
                var token = response.Content.ReadAsAsync<TokenRequest>().Result;
                var a = response.Content.ReadAsAsync<object>().Result;
                var claims = new List<Claim>()
                    {
                         new Claim(ClaimTypes.NameIdentifier,login.UserName),
                         new Claim(ClaimTypes.Name,login.UserName),
                         new Claim("AccessToken",token.username)
                    };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var prinsipal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    AllowRefresh = true
                };
                HttpContext.SignInAsync(prinsipal, properties);
                _logger.LogError("کاربر توکن را دریافت و وارد شد");

                return Redirect("/Home/Privacy");
            }
            else
            {
                ModelState.AddModelError("User ", "User not valid or Wrong password");
                return View(login);
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
