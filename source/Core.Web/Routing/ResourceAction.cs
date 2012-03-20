using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Web.Routing
{
    public class ResourceAction
    {
        public string Action { get; set; }
        public ResourceMemberType Type { get; set; }
    }

    public enum ResourceMemberType
    {
        Member,
        Collection
    }
}
