using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Starter.Web
{
    public class RouteConfigurator
    {
        public RouteConfigurator(RouteCollection routes)
        {
            this.Routes = routes;
        }

        public RouteCollection Routes { get; set; }

        public void Configure()
        {
            this.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            ConfigureDefaultRoute();
        }

        private void ConfigureDefaultRoute()
        {
            this.Routes.MapRoute(
                "default", 
                "{controller}/{action}/{id}",                                              
                new { controller = "home", action = "index", id = UrlParameter.Optional } 
            );
        }
    }
}