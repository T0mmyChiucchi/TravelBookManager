namespace TravelBookManager.SharedKernel
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object? obj)
        {
            if (obj is not ValueObject other)
                return false;

            return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
        }

        public override int GetHashCode()
        {
            return GetAtomicValues().Aggregate(0, (hash, obj) => HashCode.Combine(hash, obj));
        }
    }
}