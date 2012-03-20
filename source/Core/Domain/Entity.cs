namespace Core.Domain
{
    /// <summary>
    /// Base class that all domain Entity classes should derive from
    /// </summary>
    public abstract class Entity : IHaveId
    {
        private const int HashMultiplier = 31;

        private int _id;

        /// <summary>
        /// Id of the object
        /// </summary>
        public virtual int Id 
        { 
            get { return _id; } 
        }

        public override bool Equals(object other)
        {
            return new IdBasedEqualityComparer(this).IsEqualTo(other);
        }

        public override int GetHashCode()
        {
            if (this.HasBeenPersisted())
            {
                int hashCode = GetType().GetHashCode();
                hashCode = (hashCode * HashMultiplier) ^ this.Id.GetHashCode();
                return hashCode;
            }

            return base.GetHashCode();
        }

        public virtual bool HasBeenPersisted()
        {
            return this.Id != 0;
        }
    }
}
