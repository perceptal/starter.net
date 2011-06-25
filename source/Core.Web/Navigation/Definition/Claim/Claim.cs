using System;
using Common.Domain;

namespace Core.Web
{
    public abstract class ClaimBase
    {
        protected ClaimBase()
        {
        }

        protected ClaimBase(string securable, Right right)
        {
            this.Securable = securable;
            this.Right = right;
        }

        protected string Securable { get; set; }

        protected Right Right { get; set; }

        public static implicit operator Claim(ClaimBase builder)
        {
            return Build(builder);
        }

        public static Claim Build(ClaimBase builder)
        {
            return new Claim(builder.Securable, builder.Right);
        }
    }
}

