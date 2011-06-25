using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IMembershipService
    {
        Member Register(Member member);

        IList<Member> List();
    }
}
