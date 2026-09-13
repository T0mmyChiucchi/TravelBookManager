using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Users.Events
{
    public sealed record UserEmailChangedEvent(Guid UserId, string NewEmail) : IDomainEvent
    {
        public DateTime OccuredOnUtc { get; } = DateTime.UtcNow;
    }
}
