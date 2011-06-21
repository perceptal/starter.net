namespace Common.Domain
{
    /// <summary>
    /// Base class that all domain Entity classes should derive from
    /// </summary>
    public abstract class EntityBase : IHaveId //, IValidatable
    {
        /// <summary>
        /// To help ensure hashcode uniqueness, a carefully selected random number multiplier
        /// is used within the calculation.  Goodrich and Tamassia's Data Structures and
        /// Algorithms asserts that 31, 33, 37, 39 and 41 will produce the fewest number
        /// of collissions.  See http://computinglife.wordpress.com/2008/11/20/why-do-hash-functions-use-prime-numbers/
        /// for more information.
        /// </summary>
        private const int HashMultiplier = 31;

        /// <summary>
        /// Id of the object
        /// </summary>
        public virtual int Id { get; set; }

        public override bool Equals(object other)
        {
            return new IdBasedEqualityComparer(this).IsEqualTo(other);
        }

        public override int GetHashCode()
        {
            // We are just using the Id for the HashCode.
            // If we wanted an implementation that allowed us to indicate which properties are used in the calculation see:
            // http://sharp-architecture.googlecode.com/svn/trunk/src/SharpArch/SharpArch.Core/DomainModel/BaseObject.cs
            if (this.HasBeenPersisted())
            {
                int hashCode = GetType().GetHashCode();
                hashCode = (hashCode * HashMultiplier) ^ this.Id.GetHashCode();
                return hashCode;
            }

            return base.GetHashCode();
        }

        /// <summary>
        /// Check if this object is valid and return the results of this validation (and any errors)
        /// </summary>
        //public virtual ValidationResults Validate()
        //{
        //    return new Validator().Validate(this);
        //}

        public virtual bool HasBeenPersisted()
        {
            return this.Id != 0;
        }
    }
}
