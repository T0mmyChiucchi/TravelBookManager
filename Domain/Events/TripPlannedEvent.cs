using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Events
{
    public sealed record TripPlannedEvent : IDomainEvent
    {
        public Guid TripId { get; }
        public string TripName { get; }
        public DateTime OccuredOnUtc { get; } = DateTime.UtcNow;

        public TripPlannedEvent(Guid id, string tripName)
        {
            TripId = id;
            TripName = tripName;
        }
    }
}