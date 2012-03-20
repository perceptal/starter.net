using System.Web.Routing;

namespace Core.Web
{
    public interface IRouteConfiguration
    {
        RouteCollection Routes { get; set; }

        void Configure(RouteCollection routes);
    }
}