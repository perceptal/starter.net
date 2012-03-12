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

            Ignore();
            System();
            Default();
        }

        private void Ignore()
        {
            this.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }

        private void System()
        {
            this.Routes.MapRoute("about", "about", new { controller = "home", action = "about" });
            this.Routes.MapRoute("contact", "contact", new { controller = "home", action = "contact" });
        }

        private void Default()
        {
            this.Routes.MapRoute(
                "default",
                "{controller}/{action}/{id}",
                new { controller = "home", action = "index", id = UrlParameter.Optional },
                new[] { "Starter.Web.Controllers" }
            );
        }
    }
}