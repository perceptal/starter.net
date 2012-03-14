using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IGroupRepository
    {
        Group Get(int id);

        Group GetByCode(string code);

        IList<Group> List();

        void Submit(Group group);
    }
}
