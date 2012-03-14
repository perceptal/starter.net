using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IPersonService
    {
        Person Register(Person person);

        IList<Person> List();
    }
}
