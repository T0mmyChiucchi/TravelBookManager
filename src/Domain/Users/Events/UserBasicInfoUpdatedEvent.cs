using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Users.Events
{
    public sealed record UserBasicInfoUpdatedEvent(Guid UserId, string NewName, string NewUsername) : IDomainEvent
    {
        public DateTime OccuredOnUtc { get; } = DateTime.UtcNow;
    }
}
