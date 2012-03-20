using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IGroupService
    {
        Group Setup();

        Group Register(Group group);

        Group AddGroup(Group group, Group parent);

        Group Get(int id);

        IList<Group> ListOrganisations();

        IList<Group> ListGroups();

        IList<Group> Search(string query);
    }
}
