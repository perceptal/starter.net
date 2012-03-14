using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Domain.Implementation
{
    public class PersonService : IPersonService
    {
        public PersonService(IPersonRepository repository)
        {
            this.Repository = repository;
        }

        private IPersonRepository Repository { get; set; }

        public Person Register(Person person)
        {
            if (EmailExists(person.Email))
            {
                throw new ArgumentException("This email address has already been registered.", "email");
            }

            this.Repository.Submit(person);

            return person;
        }

        public IList<Person> List()
        {
            return this.Repository.List();
        }

        private bool EmailExists(string email)
        {
            return this.Repository.GetByEmail(email) != null;
        }
    }
}
