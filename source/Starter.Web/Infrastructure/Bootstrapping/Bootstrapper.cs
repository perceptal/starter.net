using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Common.Domain.Config;
using Core.Config;
using Core.Web;
using Core.Web.Config;

namespace Starter.Web
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
            : base(typeof(WebApplication).Assembly, new RouteConfigurator(), new FilterRegistrar(), new NavigationDefinition())
        {
        }
    }
}