using System;
using Core.Domain;

namespace Common.Domain
{
    public class Member : Entity
    {
        public virtual string Name { get; set; }

        public virtual Email Email { get; set; }

        public virtual Password Password { get; set; }

        public virtual Role Role { get; set; }
    }
}
