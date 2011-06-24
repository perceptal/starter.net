using System;
using System.Collections.Generic;
using Core.Domain;

namespace Common.Domain
{
    public class Password : ValueObject<Password>
    {
        public string Salt { get; set; }

        public string Value { get; set; }

        protected override IEnumerable<object> Reflect()
        {
            yield return Salt;
            yield return Value;
        }
    }
}
