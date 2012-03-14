using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IUserRepository
    {
        User GetByUserName(string username);

        void Submit(User user);
    }
}
