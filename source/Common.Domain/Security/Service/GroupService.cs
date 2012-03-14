using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Domain.Implementation
{
    public class GroupService : IGroupService
    {
        public GroupService(IGroupRepository repository)
        {
            this.Repository = repository;
        }

        private IGroupRepository Repository { get; set; }

        public Group Register(Group group)
        {
            if (CodeExists(group.Code))
            {
                throw new ArgumentException("This code is already in use.", "code");
            }

            this.Repository.Submit(group);

            return group;
        }

        public Group AddLocation(Group group)
        { 
            this.Repository.Submit(group);

            return group;
        }

        public IList<Group> List()
        {
            return this.Repository.List();
        }

        private bool CodeExists(string code)
        {
            return this.Repository.GetByCode(code) != null;
        }
    }
}
