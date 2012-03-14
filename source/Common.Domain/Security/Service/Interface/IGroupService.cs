using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IGroupService
    {
        Group Register(Group group);

        Group AddLocation(Group group);

        IList<Group> List();
    }
}
