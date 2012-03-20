using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Domain.Implementation
{
    class PersonFactory : IPersonFactory
    {
        private IUserFactory UserFactory { get; set; }

        public Person Create(Person person, Group group, User user)
        {
            return new Person(person)
            {
                User = user,
                Group = group,
                SecurityKey = group.SecurityKey
            };
        }
    }
}
