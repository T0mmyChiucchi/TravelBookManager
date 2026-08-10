namespace Travel_Book_Manager.SharedKernel
{
    public interface IDomainEvent
    {
        DateTime OccuredOnUtc { get; }
    }

    public abstract class DomainEvent : IDomainEvent
    {
        public DateTime OccuredOnUtc { get; } = DateTime.UtcNow;
    }
}