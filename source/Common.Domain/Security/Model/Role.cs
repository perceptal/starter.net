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
            this.Users = new HashSet<User>();
        }

        public virtual string Name { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
