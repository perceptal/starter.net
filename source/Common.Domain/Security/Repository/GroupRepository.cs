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

        public Group GetRoot()
        {
            return this.Repository.FindBy(group => group.Parent == null);
        }

        public Group GetByCode(string code)
        {
            return this.Repository.FindBy(group => group.Code == code);
        }

        public IList<Group> ListOrganisations()
        {
            return this.Repository.QueryBy(group => (int)group.Level < (int)GroupLevel.Group).ToList();
        }

        public IList<Group> ListGroups()
        {
            return this.Repository.QueryBy(group => group.Level == GroupLevel.Group).ToList();
        }

        public IList<Group> Search(string query)
        {
            return this.Repository.QueryBy(group => group.Name.Contains(query)).ToList();
        }

        public Group Submit(Group group)
        {
            this.Repository.Save(group);

            return group;
        }
    }
}
