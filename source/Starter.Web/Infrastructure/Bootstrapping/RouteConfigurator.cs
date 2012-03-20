using System;
using System.Web.Mvc;
using System.Web.Routing;
using Core.Web;
using Core.Web.Routing;

namespace Starter.Web.Infrastructure
{
    public class RouteConfigurator : RouteConfiguratorBase
    {
        public override void Configure(RouteCollection routes)
        {
            base.Configure(routes);

            Resources();
        }

        private void Resources()
        {
            var o = Resource.Named("organisations")
                .Scoped("administration")
                .With(
                    Resource.Named("permissions"),
                    Resource.Named("groups"));

            var m = Resource.Named("members")
                .Collection("search", "archived", "recent")
                .Member("lock", "unlock", "archive", "upload")
                .With(
                    Resource.Named("photos").Member("default"),
                    Resource.Named("roles"));

            AddResource(o);
            AddResource(m);
        }
    }
}