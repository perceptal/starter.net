using System;
using System.Collections.Generic;
using System.Linq;
using Common.Domain;

namespace Core.Web
{
     public class Page
    {
        public Page()
        {
            this.Parameters = new HashSet<Parameter>();
            this.Claims = new HashSet<Claim>();
        }

        public virtual string Name { get; set; }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual string Application { get; set; }

        public virtual int Index { get; set; }

        public virtual PageOption Options { get; set; }

        public virtual string Parent { get; set; }

        public virtual string Icon { get; set; }

        public virtual string Condition { get; set; }

        public virtual string Classifier { get; set; }

        public virtual string Override { get; set; }

        public virtual string ParentOverride { get; set; }

        public virtual ICollection<Parameter> Parameters { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }

        public static bool operator ==(Page x, Page y)
        {
            if (Equals(x, null) ^ Equals(y, null))
            {
                return false;
            }

            return Equals(x, null) || x.Equals(y);
        }

        public static bool operator !=(Page x, Page y)
        {
            return !(x == y);
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(null, o))
            {
                return false;
            }

            return o.GetType() == GetType() && Equals(o as Page);
        }

        public virtual bool Equals(Page other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return ReferenceEquals(this, other) || Reflect().SequenceEqual(other.Reflect());
        }

        public override int GetHashCode()
        {
            return Reflect()
                .Aggregate(
                    36,
                    (hashCode, value) =>
                        value == null
                            ? hashCode
                            : hashCode ^ value.GetHashCode());
        }

        protected IEnumerable<object> Reflect()
        {
            yield return Name;
            yield return Title;
            yield return Description;
            yield return Application;
            yield return Index;
            yield return Options;
            yield return Parent;
            yield return Icon;
            yield return Condition;
            yield return Classifier;
            yield return Override;
        }
    }
}
