using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Domain.Implementation
{
    public class MembershipService : IMembershipService
    {
        public MembershipService(IMemberRepository repository)
        {
            this.Repository = repository;
        }

        private IMemberRepository Repository { get; set; }

        public Member Register(Member member)
        {
            if (EmailExists(member.Email))
            {
                throw new ArgumentException("This email address has already been registered.", "email");
            }

            this.Repository.Submit(member);

            return member;
        }

        public IList<Member> List()
        {
            return this.Repository.List();
        }

        private bool EmailExists(string email)
        {
            return this.Repository.GetByEmail(email) != null;
        }
    }
}
