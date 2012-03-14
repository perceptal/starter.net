using System;
using System.Collections.Generic;
using System.Linq;
using Core.Persistence;

namespace Common.Domain.Implementation
{
    public class GroupRepository : IGroupRepository
    {
        private IRepository<Group> Repository { get; set; }

        public GroupRepository(IRepository<Group> repository)
        {
            this.Repository = repository;
        }

        public Group Get(int id)
        {
            return this.Repository.FindBy(group => group.Id == id);
        }

        public Group GetByCode(string code)
        {
            return this.Repository.FindBy(group => group.Code == code);
        }

        public IList<Group> List()
        {
            return this.Repository.QueryAll().ToList();
        }

        public void Submit(Group group)
        {
            this.Repository.Save(group);
        }
    }
}
