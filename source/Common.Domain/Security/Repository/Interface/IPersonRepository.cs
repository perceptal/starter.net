using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IPersonRepository
    {
        Person GetByEmail(string email);

        IList<Person> List();

        void Submit(Person person);
    }
}
