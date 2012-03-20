using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain;

namespace Core.Web.Security.Implementation
{
    public class AnonymousIdentity : IPlatformIdentity
    {
        private const string Guest = "guest";

        public ICollection<Claim> Claims { get; private set; }

        public ICollection<Role> Roles { get; private set; }

        public SecurityKey SecurityKey { get; private set; }

        public Group Group { get; private set; }

        public string AuthenticationType { get; private set; }

        public bool IsAuthenticated
        {
            get { return false; }
        }

        public string Name { get { return Guest; } }
    }
}
