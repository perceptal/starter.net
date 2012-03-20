using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Web.Routing
{
    public class ResourceData
    {
        private const string Id = "id";

        public string Name { get; set; }
        public string Scope { get; set; }
        public ResourceData Parent { get; set; }

        public List<ResourceData> Nested { get; set; }

        public List<string> Collection { get; set; }
        public List<string> Member { get; set; }
        public List<ResourceMethod> Except { get; set; }

        public string RouteName(ResourceMethod method, string on = "")
        {
            string scope = this.Scope.IsNullOrEmpty() ? string.Empty : "{0}".FormatWith(this.Scope.ToLowerInvariant());

            string parent = this.Parent == null ? string.Empty : this.Parent.RouteName(method);

            return "{0}{1}{2}{3}{4}".FormatWith(
                parent, scope, this.Name.ToLowerInvariant(), method.ToString().ToLowerInvariant(), on.ToLowerInvariant());
        }

        public string BaseUrl(string collection = "")
        {
            string url = this.Parent == null ? string.Empty : "{0}/".FormatWith(this.Parent.ItemUrl()); 
                    
            url += this.Scope.IsNullOrEmpty()
                ? "{0}/".FormatWith(this.Name)
                : "{0}/{1}/".FormatWith(this.Scope, this.Name);

            if (!collection.IsNullOrEmpty()) url += "{0}/".FormatWith(collection);

            return url;
        }

        public string ItemUrl(string member = "")
        {
            string parameter = this.Parent == null ? Id : this.ParameterName;
            string url = this.BaseUrl() + "{{{0}}}".FormatWith(parameter);
            
            if (!member.IsNullOrEmpty()) url += "/{0}/".FormatWith(member);

            return url;
        }

        public string ParameterName
        {
            get { return (this.Name.Singularize() + Id).ToLowerInvariant(); }
        }
    }

    public enum ResourceMethod
    {
        Index,
        Show,
        New,
        Create,
        Edit,
        Update,
        Destroy
    }
}
