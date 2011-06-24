using System;
using System.Collections.Generic;
using Core.Domain;

namespace Common.Domain
{
    public class Role : Entity
    {
        public Role() {}

        public Role(string name)
        {
            this.Name = name;
        }

        public virtual string Name { get; set; }
    }
}
