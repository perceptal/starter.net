using System;
using Core.Domain;

namespace Common.Domain
{
    public class User : Entity
    {
        public virtual string Logon { get; set; }

        public virtual string Password { get; set; }
    }
}
