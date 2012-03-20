using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Domain.Implementation
{
    public class GroupService : IGroupService
    {
        public GroupService(IGroupRepository repository, IGroupFactory factory)
        {
            this.Repository = repository;
            this.Factory = factory;
        }

        private IGroupRepository Repository { get; set; }

        private IGroupFactory Factory { get; set; }

        public Group Setup()
        {
            return this.Repository.Submit(this.Factory.CreateRoot());
        }

        public Group Register(Group group)
        {
            if (CodeExists(group.Code))
            {
                throw new ArgumentException("This code is already in use.", "group.Code");
            }

            return this.Repository.Submit(
                this.Factory.CreateOrganisation(group, this.Repository.GetRoot()));
        }

        public IList<Group> ListGroups()
        {
            return this.Repository.ListGroups();
        }

        public Group AddGroup(Group group, Group parent)
        {
            return this.Repository.Submit(this.Factory.CreateGroup(group, parent));
        }

        public Group Get(int id)
        {
            return this.Repository.Get(id);
        }

        public IList<Group> ListOrganisations()
        {
            return this.Repository.ListOrganisations();
        }

        public IList<Group> Search(string query)
        {
            return this.Repository.Search(query);
        }

        private bool CodeExists(string code)
        {
            return this.Repository.GetByCode(code) != null;
        }
    }
}
