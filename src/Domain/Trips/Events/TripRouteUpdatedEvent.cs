using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Trips.Events
{
    public sealed record TripRouteUpdatedEvent : IDomainEvent
    {
        public Guid TripId { get; }
        public string TripOptimizedRoute { get; }
        public double TripTotalDistance { get; }
        public DateTime OccuredOnUtc { get; } = DateTime.UtcNow;

        public TripRouteUpdatedEvent(Guid id, string tripOptimizedRoute, double tripTotalDistance)
        {
            TripId = id;
            TripOptimizedRoute = tripOptimizedRoute;
            TripTotalDistance = tripTotalDistance;
        }
    }
}