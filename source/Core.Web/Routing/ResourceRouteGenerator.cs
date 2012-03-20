using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Core.Web;

namespace Core.Web.Routing
{
    public class ResourceRouteGenerator
    {
        public ResourceRouteGenerator(RouteCollection routes)
        {
            this.Routes = routes;
        }

        private RouteCollection Routes { get; set; }
        private ResourceData Resource { get; set; }

        public void MapRoute(ResourceData resource)
        {
            resource.Collection.ForEach(c => Index(resource, c));
            Index(resource);

            resource.Member.ForEach(m => Show(resource, m));
            Show(resource);

            resource.Member.ForEach(m => New(resource, m));
            New(resource);

            resource.Member.ForEach(m => Create(resource, m));
            Create(resource);

            resource.Member.ForEach(m => Edit(resource, m));
            Edit(resource);

            resource.Member.ForEach(m => Update(resource, m));
            Update(resource);

            resource.Member.ForEach(m => Destroy(resource, m));
            Destroy(resource);
        }

        private void Index(ResourceData resource, string collection = "")
        {
            Map(resource, ResourceMethod.Index, resource.BaseUrl(collection), collection);
        }

        private void Show(ResourceData resource, string member = "")
        {
            Map(resource, ResourceMethod.Show, resource.ItemUrl(member), member);
        }

        private void New(ResourceData resource, string member = "")
        {
            Map(resource, ResourceMethod.New, resource.ItemUrl(member) + "new/", member);
        }

        private void Create(ResourceData resource, string member = "")
        {
            string url = member.IsNullOrEmpty() ? resource.BaseUrl() : resource.ItemUrl(member);

            Map(resource, ResourceMethod.Create, url, member, HttpVerbs.Post);
        }

        private void Edit(ResourceData resource, string member = "")
        {
            Map(resource, ResourceMethod.Edit, resource.ItemUrl(member) + "/edit/", member);
        }

        private void Update(ResourceData resource, string member = "")
        {
            Map(resource, ResourceMethod.Update, resource.ItemUrl(member), member, HttpVerbs.Put);
        }

        private void Destroy(ResourceData resource, string member = "")
        {
            Map(resource, ResourceMethod.Destroy, resource.ItemUrl(member), member, HttpVerbs.Delete);
        }

        private void Map(ResourceData resource, ResourceMethod method, string url, string on = "", HttpVerbs verb = HttpVerbs.Get)
        {
            this.Routes.MapRoute(resource.RouteName(method, on), url,
                new { controller = resource.Name, action = method.ToString().ToLowerInvariant() });
        }
    }
}
