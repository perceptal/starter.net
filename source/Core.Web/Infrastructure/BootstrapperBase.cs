using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Common.Domain.Config;
using Core.Config;
using Core.Web.Config;
using System.Reflection;

namespace Core.Web
{
    public class BootstrapperBase
    {
        public BootstrapperBase(
            Assembly assembly, IRouteConfiguration route, IFilterRegistrar filter, INavigationDefinition navigation, IMappingConfiguration mapping)
        {
            this.Assembly = assembly;
            this.RouteConfigurator = route;
            this.FilterRegistrar = filter;
            this.MappingConfigurator = mapping;

            this.Navigation = navigation.Get();
        }

        private Assembly Assembly { get; set; }
        private Page Navigation { get; set; }
        private IRouteConfiguration RouteConfigurator { get; set; }
        private IFilterRegistrar FilterRegistrar { get; set; }
        private IMappingConfiguration MappingConfigurator { get; set; }

        public IContainer Bootstrap(string application)
        {
            AreaRegistration.RegisterAllAreas();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new PlatformViewEngine());

            var builder = new ContainerBuilder();
            builder.RegisterControllers(this.Assembly);

            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterModule(new CoreModule());
            builder.RegisterModule(new CoreWebModule(this.Navigation));
            builder.RegisterModule(new CommonDomainModule(application));

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            this.FilterRegistrar
                .RegisterGlobalFilters(GlobalFilters.Filters)
                .RegisterFilters(GlobalFilters.Filters);
            this.RouteConfigurator.Configure(RouteTable.Routes);
            this.MappingConfigurator.Configure();

            return container;
        }
    }
}