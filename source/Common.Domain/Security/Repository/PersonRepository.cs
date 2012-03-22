using System;
using System.Collections.Generic;
using System.Linq;
using Core.Persistence;

namespace Common.Domain.Implementation
{
    public class PersonRepository : IPersonRepository
    {
        private IRepository<Person> Repository { get; set; }

        public PersonRepository(IRepository<Person> repository)
        {
            this.Repository = repository;
        }

        public Person Get(int id)
        {
            return this.Repository.FindBy(person => person.Id == id);
        }

        public Person GetByEmail(string email)
        {
            return this.Repository.FindBy(person => person.Email.Value == email);
        }

        public IList<Person> List()
        {
            return this.Repository.QueryAll().ToList();
        }

        public IList<Person> Search(string query)
        {
            return this.Repository.QueryBy(
                person => person.FirstName.StartsWith(query) || person.LastName.StartsWith(query)).ToList();
        }

        public Person Submit(Person person)
        {
            this.Repository.Save(person);

            return person;
        }
    }
}
