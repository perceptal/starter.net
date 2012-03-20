using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using Common.Domain;

namespace Core.Web.Security
{
    public interface IPlatformIdentity : IIdentity
    {
        ICollection<Claim> Claims { get; }

        ICollection<Role> Roles { get; }

        SecurityKey SecurityKey { get; }

        Group Group { get; }
    }
}
