using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IPersonService
    {
        Person Register(Person person, Group group);

        Person Save(Person person);

        Person Get(int id);

        IList<Person> List();

        IList<Person> Search(string query);

        IList<Person> Archived();

        IList<Person> Favourites(int personId);

        IList<Person> Recent(int personId);
    }
}
