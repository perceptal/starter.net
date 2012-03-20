using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IPersonRepository
    {
        Person Get(int id);

        Person GetByEmail(string email);

        IList<Person> List();

        Person Submit(Person person);
    }
}
