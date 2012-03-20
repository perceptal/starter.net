using System;
using System.Collections.Generic;
using Core.Domain;

namespace Common.Domain
{
    public class Group : Entity
    {
        public Group()
        {
            this.Children = new HashSet<Group>();
            this.Persons = new HashSet<Person>();
            this.Roles = new HashSet<Role>();
        }

        public Group(string name) : this()
        {
            this.Name = name;
        }

        public Group(string name, string code, string email, string contact) : this(name)
        {
            this.Code = code;
            this.Email = email;
            this.Contact = contact;
        }

        public virtual string Name { get; set; }

        public virtual string Code { get; set; }

        public virtual Email Email { get; set; }

        public virtual Contact Contact { get; set; }

        public virtual bool IsPrimary { get; set; }

        public virtual GroupLevel Level { get; set; }

        public virtual SecurityKey SecurityKey { get; set; }

        public virtual Group Parent { get; set; }

        public virtual ICollection<Group> Children { get; set; }

        public virtual ICollection<Person> Persons { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }

    public enum GroupLevel
    {
        System = 0,
        Organisation = 1,
        Group = 2
    }
}
