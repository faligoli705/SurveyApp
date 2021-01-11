using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.DataAccessLayer;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;

namespace SurveyApp.WebFramework.Configuration
{
    public static class IdentityConfigurationExtensions
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<Users, Roles>(identityOptions =>
            {
                //Password Settings
                identityOptions.Password.RequireDigit = false;
                identityOptions.Password.RequiredLength = 6;
                identityOptions.Password.RequireNonAlphanumeric = false; //#@!
                identityOptions.Password.RequireUppercase = false;
                identityOptions.Password.RequireLowercase = false;

                //UserName Settings
                identityOptions.User.RequireUniqueEmail =false;

                //Singin Settings
                //identityOptions.SignIn.RequireConfirmedEmail = false;
                //identityOptions.SignIn.RequireConfirmedPhoneNumber = false;

                //Lockout Settings
                //identityOptions.Lockout.MaxFailedAccessAttempts = 5;
                //identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                //identityOptions.Lockout.AllowedForNewUsers = false;
            })
            .AddEntityFrameworkStores<SurveyAppDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}