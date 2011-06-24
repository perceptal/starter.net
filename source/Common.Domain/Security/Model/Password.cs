﻿using System;
using System.Collections.Generic;
using Core.Domain;

namespace Common.Domain
{
    public class Password : ValueObject<Password>
    {
        public Password() {}

        public Password(string password, string salt)
        {
            this.Salt = salt;
            this.Value = password;
        }

        public string Salt { get; private set; }

        public string Value { get; private set; }

        protected override IEnumerable<object> Reflect()
        {
            yield return Salt;
            yield return Value;
        }
    }
}