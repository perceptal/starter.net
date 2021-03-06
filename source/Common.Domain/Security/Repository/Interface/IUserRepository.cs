﻿using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IUserRepository
    {
        User GetByUserName(string username);

        User Submit(User user);
    }
}
