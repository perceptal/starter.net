using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain;

namespace Core.Web.Security.Implementation
{
    public class PlatformIdentity : IPlatformIdentity
    {
        public PlatformIdentity(User user)
        {
            this.Claims = new HashSet<Claim>();
            foreach (var role in user.Roles)
            {
                this.Claims.Concat(role.Claims);
            }

            this.Roles = user.Roles;
            this.SecurityKey = user.Person.SecurityKey;
            this.Group = user.Person.Group;
            this.Name = user.Username;
        }

        public ICollection<Claim> Claims { get; private set; }

        public ICollection<Role> Roles { get; private set; }

        public SecurityKey SecurityKey { get; private set; }

        public Group Group { get; private set; }

        public string AuthenticationType { get; private set; }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name { get; private set; }
    }
}
