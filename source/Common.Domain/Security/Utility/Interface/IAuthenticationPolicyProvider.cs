using System;

namespace Common.Domain
{
    public interface IAuthenticationPolicyProvider
    {
        short MaximumAuthenticationFailuresBeforeLock { get; }

        Password GenerateRandomPassword(string logon);

        Password GeneratePassword(string logon, string password);
    }
}
