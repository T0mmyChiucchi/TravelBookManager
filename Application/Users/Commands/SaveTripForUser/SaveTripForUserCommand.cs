using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Users.Commands.SaveTripForUser
{
    public sealed record SaveTripForUserCommand(Guid UserId, Guid TripId) : ICommand<Guid>;
}