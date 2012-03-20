using System;

namespace Common.Domain
{
    public interface IGroupFactory
    {
        Group CreateRoot();

        Group CreateOrganisation(Group group, Group root);

        Group CreateGroup(Group group, Group parent);
    }
}
