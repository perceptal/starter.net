using System;
using System.Web.Security;

namespace Common.Domain.Implementation
{
    public class FormsAuthenticationHashProvider : IHashProvider
    {
        private const string Sha1 = "SHA1";

        public string HashData(string data)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(data, Sha1);
        }
    }
}
