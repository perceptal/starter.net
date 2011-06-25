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

        public static implicit operator Email(string email)
        {
            return new Email(email);
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }

        protected override IEnumerable<object> Reflect()
        {
            yield return Value;
        }
    }
}
