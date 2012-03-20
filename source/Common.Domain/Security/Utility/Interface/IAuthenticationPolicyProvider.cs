using System;

namespace Common.Domain
{
    public interface IAuthenticationPolicyProvider
    {
        short MaximumAuthenticationFailuresBeforeLock { get; }

        Password GenerateRandomPassword(string username);

        Password GeneratePassword(string username, string password);
    }
}
