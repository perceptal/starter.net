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

        public virtual Password GenerateRandomPassword(string logon)
        {
            return GeneratePassword(logon, this.SaltProvider.GenerateSalt());
        }

        public abstract short MaximumAuthenticationFailuresBeforeLock { get; }

        public Password GeneratePassword(string logon, string password)
        {
            String salt = this.SaltProvider.GenerateSalt();

            return new Password(salt, this.HashProvider.HashData(logon + password + salt));
        }
    }
}
