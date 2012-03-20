using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Core.Web;

namespace Core.Web.Routing
{
    public class RouteConfiguratorBase : IRouteConfiguration
    {
        private ResourceRouteGenerator ResourceRouteGenerator { get; set; }

        public RouteCollection Routes { get; set; }

        public virtual void Configure(RouteCollection routes)
        {
            this.Routes = routes;
            this.ResourceRouteGenerator = new ResourceRouteGenerator(this.Routes);

            Ignore();
            Default();
        }

        private void Ignore()
        {
            this.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }

        private void Default()
        {
            this.Routes.MapRoute("default", "{controller}/{action}/{id}",
                new { controller = "home", action = "index", id = UrlParameter.Optional });
        }

        protected void AddResource(ResourceData resource)
        {
            this.ResourceRouteGenerator.MapRoute(resource);

            resource.Nested.ForEach(nested => AddResource(nested));
        }
    }
}