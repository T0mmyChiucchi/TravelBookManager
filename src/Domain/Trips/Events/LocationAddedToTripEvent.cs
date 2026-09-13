using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Trips.Events
{
    public sealed record LocationAddedToTripEvent : IDomainEvent
    {
        public Guid TripId { get; }
        public Guid AddedLocationId { get; }
        public DateTime OccuredOnUtc { get; } = DateTime.UtcNow;

        public LocationAddedToTripEvent(Guid id, Guid addedLocationId)
        {
            TripId = id;
            AddedLocationId = addedLocationId;
        }
    }
}