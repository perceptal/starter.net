using System;
using System.Collections.Generic;
using Core.Domain;

namespace Common.Domain
{
    public class Role : Entity
    {
        public Role() 
        {
            this.Claims = new HashSet<Claim>();
        }

        public virtual string Name { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
    }
}
