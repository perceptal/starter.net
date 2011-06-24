using System;
using System.Collections.Generic;
using Core.Domain;

namespace Common.Domain
{
    public class Email : ValueObject<Email>
    {
        public Email() {}

        public Email(string email)
        {
            this.Value = email;
        }

        public string Value { get; private set; }

        protected override IEnumerable<object> Reflect()
        {
            yield return Value;
        }
    }
}
