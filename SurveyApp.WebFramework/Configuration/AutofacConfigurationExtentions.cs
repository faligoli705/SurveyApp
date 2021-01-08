using Autofac;
using Autofac.Extensions.DependencyInjection;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.DataAccessLayer;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using SurveyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.WebFramework.Configuration
{
    public static class AutofacConfigurationExtentions
    {
        public static void AddServices(this ContainerBuilder containerBuilder)
        {


            var commonAssembly = typeof(SiteSetting).Assembly;
            var domainClassAssembly = typeof(IEntity).Assembly;
            var dataAccessLayerAssembly = typeof(SurveyAppDbContext).Assembly;
            var servicesAssembly = typeof(JwtService).Assembly;
            containerBuilder.RegisterAssemblyTypes(commonAssembly, domainClassAssembly, dataAccessLayerAssembly, servicesAssembly)
                .AssignableTo<IScopedDependency>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterAssemblyTypes(commonAssembly, domainClassAssembly, dataAccessLayerAssembly, servicesAssembly)
                .AssignableTo<ITransientDependency>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            containerBuilder.RegisterAssemblyTypes(commonAssembly, domainClassAssembly, dataAccessLayerAssembly, servicesAssembly)
                .AssignableTo<ISingletonDependency>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }

        public static IServiceProvider BuildAutofactServiceProvider(this IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.AddServices();
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
