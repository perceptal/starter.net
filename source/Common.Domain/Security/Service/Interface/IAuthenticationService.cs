﻿using System;

namespace Common.Domain
{
    public interface IAuthenticationService
    {
        bool Authenticate(Member user);
    }
}
