using System;
using FluentNHibernate.Mapping;

namespace Common.Domain.Implementation
{
    internal class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(user => user.Id);
            Map(user => user.Logon);
            Map(user => user.Password);
        }
    }
}
