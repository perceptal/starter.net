using System;
using System.Collections.Generic;
using Core;
using Core.Domain;

namespace Common.Domain
{
    public class SecurityKey : ValueObject<SecurityKey>
    {
        protected SecurityKey()
        {
        }

        public SecurityKey(long low, long high)
        {
            this.Low = low;
            this.High = high;
        }

        public long Low { get; private set; }

        public long High { get; private set; }

        protected override IEnumerable<object> Reflect()
        {
            yield return this.Low;
            yield return this.High;
        }

        protected override bool ValuesAreEqual(SecurityKey other)
        {
            return this.Low == other.Low && this.High == other.High;
        }

        public override bool Equals(SecurityKey other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return ReferenceEquals(this, other) || base.ValuesAreEqual(other);
        }

        public static implicit operator string(SecurityKey key)
        {
            return key.ToString();
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", this.Low, this.High);
        }
    }
}
