using System;
using Core.Persistence;

namespace Common.Domain.Implementation
{
    public class MemberRepository : IMemberRepository
    {
        private IRepository<Member> Repository { get; set; }

        public MemberRepository(IRepository<Member> repository)
        {
            this.Repository = repository;
        }

        public Member GetByEmail(string email)
        {
            return this.Repository.FindBy(member => member.Email.Value == email);
        }

        public void Submit(Member member)
        {
            this.Repository.Save(member);
        }
    }
}
