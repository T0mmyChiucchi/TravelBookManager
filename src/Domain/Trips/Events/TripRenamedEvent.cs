using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Trips.Events
{
    public sealed record TripRenamedEvent : IDomainEvent
    {
        public Guid TripId { get; }
        public string TripName { get; }
        public DateTime OccuredOnUtc { get; } = DateTime.UtcNow;

        public TripRenamedEvent(Guid id, string tripName)
        {
            TripId = id;
            TripName = tripName;
        }
    }
}