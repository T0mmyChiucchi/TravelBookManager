using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Users.Events
{
    public sealed record UserPasswordChangedEvent(Guid UserId) : IDomainEvent
    {
        public DateTime OccuredOnUtc { get; } = DateTime.UtcNow;
    }
}
