using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Domain.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService(IMemberRepository repository, IAuthenticationPolicyProvider policy)
        {
            this.Repository = repository;
            this.Policy = policy;
        }

        private IMemberRepository Repository { get; set; }

        private IAuthenticationPolicyProvider Policy { get; set; }

        public bool Authenticate(Member user)
        {
            return true;
        }
    }
}
