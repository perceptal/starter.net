using System;

namespace Common.Domain
{
    public interface IAuthenticationService
    {
        bool Authenticate(User user);
    }
}
