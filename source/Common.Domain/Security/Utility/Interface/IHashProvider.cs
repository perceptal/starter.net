using System;

namespace Common.Domain
{
    public interface IHashProvider
    {
        string HashData(string data);
    }
}
