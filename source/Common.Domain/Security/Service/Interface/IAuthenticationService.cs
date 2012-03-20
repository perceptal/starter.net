using System;

namespace Common.Domain
{
    public interface IAuthenticationService
    {
        bool Authenticate(string username, string password);
    }
}
