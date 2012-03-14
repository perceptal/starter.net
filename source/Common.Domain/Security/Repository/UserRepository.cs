using System;
using System.Collections.Generic;
using System.Linq;
using Core.Persistence;

namespace Common.Domain.Implementation
{
    public class UserRepository : IUserRepository
    {
        private IRepository<User> Repository { get; set; }

        public UserRepository(IRepository<User> repository)
        {
            this.Repository = repository;
        }

        public User GetByUserName(string username)
        {
            return this.Repository.FindBy(user => user.Username == username);
        }

        public void Submit(User user)
        {
            this.Repository.Save(user);
        }
    }
}
