using System;
using System.Collections.Generic;
using Core;
using Core.Domain;

namespace Common.Domain
{
    public class Claim : ValueObject<Claim>
    {
        protected Claim()
        {
        }

        public Claim(string securable, Right right)
        {
            Enforce.Argument(() => securable, "securable");
            Enforce.ArgumentNotNull(() => right, "right");

            this.Securable = securable;
            this.Right = right;
        }

        public string Securable { get; private set; }

        public Right Right { get; private set; }

        protected override IEnumerable<object> Reflect()
        {
            yield return this.Securable;
            yield return this.Right;
        }

        /// <summary>
        /// Override for performance reasons (to avoid creating an IEnumerable instance)
        /// because there can be lots of Claim instances so Equals method is called a lot
        /// </summary>
        protected override bool ValuesAreEqual(Claim other)
        {
            return this.Securable == other.Securable && this.Right == other.Right;
        }

        public override bool Equals(Claim other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return ReferenceEquals(this, other) || base.ValuesAreEqual(other);
        }

        public static implicit operator string(Claim claim)
        {
            return claim.ToString();
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Securable, this.Right);
        }
    }
}
