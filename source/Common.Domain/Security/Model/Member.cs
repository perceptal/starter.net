using System;
using System.Collections.Generic;
using Core.Domain;

namespace Common.Domain
{
    public class Member : Entity
    {
        public Member()
        {
            this.Accounts = new HashSet<Account>();
        }

        public virtual string Name { get; set; }

        public virtual Email Email { get; set; }

        public virtual Password Password { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
