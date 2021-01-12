
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.DataAccessLayer;
using SurveyApp.DataAccessLayer.Contracts;
using SurveyApp.Infrastucture;
using SurveyApp.Services;
using SurveyApp.WebFramework.Configuration;
using SurveyApp.WebFramework.CustomMapping;
using SurveyApp.WebFramework.Middlewares;
using SurveyApp.WebFramework.Swagger;

namespace SurveyApp
{
    public class Startup
    {
        private readonly IdentitySettings _identitySettings;
        private readonly JwtSettings _jwtSettings;
         public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _identitySettings = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>();
            _jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SiteSetting>(Configuration.GetSection(nameof(SiteSetting)));
            services.InitializeAutoMapper();

            services.AddDbContext(Configuration);

            services.AddCustomIdentity(_identitySettings);

            services.AddMinimalMvc();

            services.AddJwtAuthentication(_jwtSettings);
            services.AddScoped<IJwtService, JwtService>();

            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
            app.UseEndpoints(config =>
            {
                config.MapControllers(); // Map attribute routing
            });

        }
    }
}