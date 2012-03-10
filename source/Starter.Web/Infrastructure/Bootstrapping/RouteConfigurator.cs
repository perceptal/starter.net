using System;
using System.Web.Mvc;
using System.Web.Routing;
using Core.Web;

namespace Starter.Web
{
    public class RouteConfigurator : IRouteConfiguration
    {
        public RouteCollection Routes { get; set; }

        public void Configure(RouteCollection routes)
        {
            this.Routes = routes;

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