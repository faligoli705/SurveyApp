using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SurveyApp.Infrastucture;
using SurveyApp.WebFramework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSurveyApp.Configuration;
using WebSurveyApp.Service;

namespace WebSurveyApp
{
    public class Startup
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IdentitySettings _identitySettings;
         public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _identitySettings = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>();
            _jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
          
            InitServices(services);
            services.AddService();
            services.AddControllersWithViews();           
            services.AddJwtAuthentication();

             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();
             app.UseRouting();
            app.UseAuthentication();
            app.UseCors("EnableCors");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
        }
        public void InitServices(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

        }
    }
}
