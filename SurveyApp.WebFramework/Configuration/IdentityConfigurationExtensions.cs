using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.DataAccessLayer;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;

namespace SurveyApp.WebFramework.Configuration
{
    public static class IdentityConfigurationExtensions
    {
        public static void AddCustomIdentity(this IServiceCollection services, IdentitySettings settings)
        {
            services.AddIdentity<Users, Roles>(identityOptions =>
            {
                //Password Settings
                identityOptions.Password.RequireDigit = settings.PasswordRequireDigit; //کاراکتر عددی باشد یا خیر
                identityOptions.Password.RequiredLength = settings.PasswordRequiredLength; //حداقل طول پسورد
                identityOptions.Password.RequireNonAlphanumeric = settings.PasswordRequireNonAlphanumeric; //#@!
                identityOptions.Password.RequireUppercase = settings.PasswordRequireUppercase;
                identityOptions.Password.RequireLowercase = settings.PasswordRequireLowercase;

                //UserName Settings
                identityOptions.User.RequireUniqueEmail = settings.RequireUniqueEmail;

                //Singin Settings
                //identityOptions.SignIn.RequireConfirmedEmail = false;
                //identityOptions.SignIn.RequireConfirmedPhoneNumber = false;

                //Lockout Settings
                //identityOptions.Lockout.MaxFailedAccessAttempts = 5;  //حداکثر تعداد اشتباه
                //identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // مدت تایم قفل بودن بعد از اشتباه وارد کردن
                //identityOptions.Lockout.AllowedForNewUsers = false;  //برای کابرای جدید هم فعال باشد
            })
            .AddEntityFrameworkStores<SurveyAppDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}