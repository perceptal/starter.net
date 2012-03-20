using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IGroupRepository
    {
        Group Get(int id);

        Group GetRoot();

        Group GetByCode(string code);

        IList<Group> ListOrganisations();

        IList<Group> ListGroups();

        IList<Group> Search(string query);

        Group Submit(Group group);
    }
}
