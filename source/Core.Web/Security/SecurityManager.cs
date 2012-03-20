using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Web.Security.Implementation
{
    public class SecurityManager : ISecurityManager
    {
        public SecurityManager()
        {
        }

        public SecurityManager(IPlatformIdentity identity)
        {
            this.Identity = identity;
        }

        public IPlatformIdentity Identity { get; private set; }
    }
}
