using System;

namespace Common.Domain
{
    public interface IMemberRepository
    {
        Member GetByEmail(string email);

        void Submit(Member member);
    }
}
