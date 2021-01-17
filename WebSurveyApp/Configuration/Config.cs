using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using SurveyApp.Infrastucture.Execptions;
using SurveyApp.Infrastucture.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebSurveyApp.Service;

namespace WebSurveyApp.Configuration
{
    public static class Config
    {

        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

        }

        public static void AddJwtAuthentication(this IServiceCollection services)
        {

            services.AddHttpClient("ClientSurveyApp", client =>
            {
                client.BaseAddress = new Uri("https://localhost:44357");
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Home/Login";
                    options.LogoutPath = "/Home/SignOut";
                    options.Cookie.Name = "User.Coo";
                });
            
        }
    }
}