using System;

namespace Common.Domain.Implementation
{
    public class AuthenticationPolicyProvider : AuthenticationPolicyProviderBase
    {
        private const int DefaultMaximumAuthenticationFailuresBeforeLock = 3;

        public AuthenticationPolicyProvider(IHashProvider hash, ISaltProvider salt)
            : base(hash, salt)
        { }

        public override Int16 MaximumAuthenticationFailuresBeforeLock
        {
            get { return DefaultMaximumAuthenticationFailuresBeforeLock; }
        }
    }
}
