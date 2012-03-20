using System;

namespace Common.Domain
{
    public interface IUserFactory
    {
        User Create(string username);
    }
}
