
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.DataAccessLayer;
using SurveyApp.DataAccessLayer.Contracts;
using SurveyApp.DataAccessLayer.Repositories;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using SurveyApp.Services;

namespace SurveyApp.WebFramework.Configuration
{
    public static class AutofacConfigurationExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();

            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IOfferedAnswerRepository), typeof(OfferedAnswerRepository));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IQuestionRepository), typeof(QuestionRepository));
            services.AddScoped(typeof(ISurveyAnswerRepository), typeof(SurveyAnswerRepository));
            services.AddScoped(typeof(IAuthenRepository), typeof(AuthenRepository));
        }
            //    //RegisterType > As > Liftetime
            //    //containerBuilder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerLifetimeScope();
            //     services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            //    var commonAssembly = typeof(SiteSetting).Assembly;
            //    var entitiesAssembly = typeof(IEntity).Assembly;
            //    var dataAssembly = typeof(SurveyAppDbContext).Assembly;
            //    var servicesAssembly = typeof(JwtService).Assembly;

            //    //containerBuilder.RegisterAssemblyTypes(commonAssembly, entitiesAssembly, dataAssembly, servicesAssembly)
            //    //    .AssignableTo<IScopedDependency>()
            //    //    .AsImplementedInterfaces()
            //    //    .InstancePerLifetimeScope();

            //    //containerBuilder.RegisterAssemblyTypes(commonAssembly, entitiesAssembly, dataAssembly, servicesAssembly)
            //    //    .AssignableTo<ITransientDependency>()
            //    //    .AsImplementedInterfaces()
            //    //    .InstancePerDependency();

            //    //containerBuilder.RegisterAssemblyTypes(commonAssembly, entitiesAssembly, dataAssembly, servicesAssembly)
            //    //    .AssignableTo<ISingletonDependency>()
            //    //    .AsImplementedInterfaces()
            //    //    .SingleInstance();
            //}
        }
}