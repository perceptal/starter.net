using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Domain.Implementation
{
    public class PersonService : IPersonService
    {
        public PersonService(IPersonRepository pr, IPersonFactory pf, IUserRepository ur, IUserFactory uf)
        {
            this.PersonRepository = pr;
            this.PersonFactory = pf;
            this.UserRepository = ur;
            this.UserFactory = uf;
        }

        private IPersonRepository PersonRepository { get; set; }
        private IUserRepository UserRepository { get; set; }

        private IPersonFactory PersonFactory { get; set; }
        private IUserFactory UserFactory { get; set; }

        public Person Register(Person person, Group group)
        {
            ValidateEmail(person);

            var user = this.UserRepository.Submit(this.UserFactory.Create(person.FirstName + person.LastName));
            return this.PersonRepository.Submit(this.PersonFactory.Create(person, group, user));
        }

        public Person Save(Person person)
        {
            //ValidateEmail(person);
            return this.PersonRepository.Submit(person);
        }

        public IList<Person> List()
        {
            return this.PersonRepository.List();
        }

        private void ValidateEmail(Person person)
        {
            if (EmailExists(person))
            {
                throw new ArgumentException("This email address has already been registered.", "person.Email");
            }
        }

        private bool EmailExists(Person person)
        {
            return this.PersonRepository.GetByEmail(person.Email) != null;
        }
    }
}
