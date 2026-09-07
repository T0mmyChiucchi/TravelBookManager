using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Trips.Events
{
    public sealed record LocationRemovedFromTripEvent : IDomainEvent
    {
        public Guid TripId { get; }
        public Guid RemovedLocationId { get; }
        public DateTime OccuredOnUtc { get; } = DateTime.UtcNow;

        public LocationRemovedFromTripEvent(Guid id, Guid removedLocationId)
        {
            TripId = id;
            RemovedLocationId = removedLocationId;
        }
    }
}