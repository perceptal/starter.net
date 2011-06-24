using System;
using System.Security.Cryptography;

namespace Common.Domain.Implementation
{
    public class CryptoSaltProvider : ISaltProvider
    {
        private const int DefaultSaltLength = 16;

        public string GenerateSalt()
        {
            return GenerateSalt(DefaultSaltLength);
        }

        public string GenerateSalt(int length)
        {
            var rng = new RNGCryptoServiceProvider();
            var buffer = new byte[length];
            rng.GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }
    }
}
