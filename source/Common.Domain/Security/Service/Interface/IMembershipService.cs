using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IMembershipService
    {
        Member Register();

        IList<Member> List();
    }
}
