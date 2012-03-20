using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IPersonService
    {
        Person Register(Person person, Group group);

        Person Save(Person person);

        IList<Person> List();
    }
}
