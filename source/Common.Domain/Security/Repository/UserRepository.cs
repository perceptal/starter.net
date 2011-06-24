using System;
using Core.Persistence;

namespace Common.Domain.Implementation
{
    public class UserRepository : IUserRepository
    {
        private IRepository Repository { get; set; }

        public UserRepository(IRepository repository)
        {
            this.Repository = repository;
        }
    }
}
