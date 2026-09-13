using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Users.Events
{
    public sealed record UserRegisteredEvent : IDomainEvent
    {
        public Guid UserId { get; }
        public string Email { get; }
        public DateTime OccuredOnUtc { get; } = DateTime.UtcNow;

        public UserRegisteredEvent(Guid userId, string email)
        {
            UserId = userId;
            Email = email;
        }
    }
}