using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IPersonRepository
    {
        Person Get(int id);

        Person GetByEmail(string email);

        IList<Person> List();

        IList<Person> Search(string query);

        Person Submit(Person person);
    }
}
