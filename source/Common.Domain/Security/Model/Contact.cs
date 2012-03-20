using System;
using System.Collections.Generic;
using Core.Domain;
using Core;

namespace Common.Domain
{
    public class Contact : ValueObject<Contact>
    {
        public Contact() : this(string.Empty)
        {
        }

        public Contact(string number) : this(number, ContactType.Home)
        {
        }

        public Contact(string number, ContactType type)
        {
            Enforce.Argument(() => number, "number");
            Enforce.ArgumentNotNull(() => type, "type");

            this.Number = number;
            this.Type = type;
        }

        public string Number { get; private set; }

        public ContactType Type { get; private set; }

        public static implicit operator Contact(string number)
        {
            return new Contact(number);
        }

        public static implicit operator string(Contact contact)
        {
            return contact == null ? string.Empty : contact.Number;
        }

        protected override IEnumerable<object> Reflect()
        {
            yield return Number;
            yield return Type;
        }
    }

    public enum ContactType
    {
        Home,
        Work,
        Mobile,
        Fax
    }
}
