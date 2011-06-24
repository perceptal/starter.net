using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain
{
    public abstract class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> Reflect();

        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            if (Equals(x, null) ^ Equals(y, null))
            {
                return false;
            }

            return Equals(x, null) || x.Equals(y);
        }

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
        {
            return !(x == y);
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(null, o))
            {
                return false;
            }

            return o.GetType() == GetType() && Equals(o as T);
        }

        public override int GetHashCode()
        {
            int seed = 36;

            int hc = Reflect()
                .Aggregate(
                    seed,
                    (hashCode, value) =>
                        value == null
                            ? hashCode
                            : CalculateHashCode(hashCode, value, ++seed));

            return hc;
        }

        private int CalculateHashCode(int hc, object value, int multiplier)
        {
            return (hc ^ value.GetHashCode()) * multiplier;
        }

        public virtual bool Equals(T other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return ReferenceEquals(this, other) || this.ValuesAreEqual(other);
        }

        /// <summary>
        /// Uses the Reflect Method to determine whether values are equal - you can override if this is not the behaviour you require
        /// </summary>
        protected virtual bool ValuesAreEqual(T other)
        {
            return Reflect().SequenceEqual(other.Reflect());
        }

        public override string ToString()
        {
            return "{ " + (string)Reflect().Aggregate((l, r) => l + ", " + r) + " }";
        }
    }
}
