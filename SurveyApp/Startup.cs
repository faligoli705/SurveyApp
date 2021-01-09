using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SurveyApp.Infrastucture;
using SurveyApp.WebFramework.Configuration;
using SurveyApp.WebFramework.CustomMapping;
using SurveyApp.WebFramework.Middlewares;
using SurveyApp.WebFramework.Swagger;

namespace SurveyApp
{
    public class Startup
    {
        private readonly SiteSetting _siteSetting;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
             
            _siteSetting=configuration.GetSection(nameof(SiteSetting)).Get<SiteSetting>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SiteSetting>(Configuration.GetSection(nameof(SiteSetting)));

            services.InitializeAutoMapper();

            services.AddDbContext(Configuration);

            //services.AddCustomIdentity(_siteSetting.IdentitySettings);

            services.AddMinimalMvc();


            //services.AddJwtAuthentication(_siteSetting.JwtSettings);



            services.AddSwagger();

            // Don't create a ContainerBuilder for Autofac here, and don't call builder.Populate()
            // That happens in the AutofacServiceProviderFactory for you.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.IntializeDatabase();
            app.UseCustomExceptionHandler();
            app.UseHsts(env);
            app.UseHttpsRedirection();
            app.UseSwaggerAndUI();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(config =>
            {
                config.MapControllers();
            });
        }
    }
}
