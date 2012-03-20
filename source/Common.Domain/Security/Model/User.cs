using System;
using System.Collections.Generic;
using Core.Domain;

namespace Common.Domain
{
    public class User : Entity
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }

        public User(string username) : this()
        {
            this.Username = username;
        }

        public virtual string Username { get; set; }

        public virtual Password Password { get; set; }

        public virtual bool ForcePasswordChange { get; set; }

        public virtual bool IsLocked { get; set; }

        public virtual int FailedSignOnAttempts { get; set; }

        public virtual string Ip { get; set; }

        public virtual DateTime? LastSignOnAt { get; set; }

        public virtual bool IsSupport { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
