using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IMemberRepository
    {
        Member GetByEmail(string email);

        IList<Member> List();

        void Submit(Member member);
    }
}
