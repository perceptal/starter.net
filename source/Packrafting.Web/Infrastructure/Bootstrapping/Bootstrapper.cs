using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Common.Domain.Config;
using Core.Config;
using Core.Web.Config;

namespace Packrafting.Web
{
    public class Bootstrapper
    {
        private const string Application = "packrafting";

        public IContainer Bootstrap()
        {
            AreaRegistration.RegisterAllAreas();

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterModule(new CoreModule());
            builder.RegisterModule(new CoreWebModule());
            builder.RegisterModule(new CommonDomainModule(Application));

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            new FilterRegistrar().RegisterGlobalFilters(GlobalFilters.Filters);
            new RouteConfigurator(RouteTable.Routes).Configure();

            return container;
        }
    }
}