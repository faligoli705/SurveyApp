
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.DataAccessLayer;
using SurveyApp.DataAccessLayer.Contracts;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using SurveyApp.Services;

namespace SurveyApp.WebFramework.Configuration
{
    public static class AutofacConfigurationExtensions
    {
        //public static void AddServices(this IServiceCollection services)
        //{
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