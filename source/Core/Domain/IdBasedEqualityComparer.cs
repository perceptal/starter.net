using System;

namespace Core.Domain
{
    public class IdBasedEqualityComparer
    {
        protected readonly IHaveId First;

        public IdBasedEqualityComparer(IHaveId first)
        {
            this.First = first;
        }

        public bool IsEqualTo(object o)
        {
            var compare = o as IHaveId;

            if (ReferenceEquals(null, compare))
            {
                return false;
            }

            if (ReferenceEquals(this.First, compare))
            {
                return true;
            }

            if (this.First.GetType() != compare.GetType())
            {
                return false;
            }

            return this.First.Id == compare.Id;
        }
    }
}
