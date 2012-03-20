using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Domain.Implementation
{
    public abstract class AuthenticationPolicyProviderBase : IAuthenticationPolicyProvider
    {
        IHashProvider HashProvider { get; set; }
        ISaltProvider SaltProvider { get; set; }

        protected AuthenticationPolicyProviderBase(IHashProvider hashingProvider, ISaltProvider saltProvider)
        {
            this.HashProvider = hashingProvider;
            this.SaltProvider = saltProvider;
        }

        public virtual Password GenerateRandomPassword(string username)
        {
            return GeneratePassword(username, this.SaltProvider.GenerateSalt());
        }

        public abstract short MaximumAuthenticationFailuresBeforeLock { get; }

        public Password GeneratePassword(string username, string password)
        {
            string salt = this.SaltProvider.GenerateSalt();

            return new Password(this.HashProvider.HashData(username + password + salt), salt);
        }
    }
}
