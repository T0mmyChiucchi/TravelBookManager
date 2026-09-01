using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Destinations.Events
{
    public sealed record DestinationVisitedEvent : IDomainEvent
    {
        public Guid UserId { get; }
        public Guid DestinationId { get; }
        public DateTime OccuredOnUtc { get; } = DateTime.UtcNow;

        public DestinationVisitedEvent(Guid userId, Guid destinationId)
        {
            UserId = userId;
            DestinationId = destinationId;
        }
    }
}