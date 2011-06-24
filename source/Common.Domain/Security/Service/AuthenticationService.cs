using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Domain.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService(IUserRepository repository, IAuthenticationPolicyProvider policy)
        {
            this.Repository = repository;
            this.Policy = policy;
        }

        private IUserRepository Repository { get; set; }

        private IAuthenticationPolicyProvider Policy { get; set; }

        public bool Authenticate(User user)
        {
            return true;
        }
    }
}
