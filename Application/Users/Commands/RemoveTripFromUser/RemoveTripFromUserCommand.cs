using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Users.Commands.RemoveTripFromUser
{
    public sealed record RemoveTripFromUserCommand(Guid UserId, Guid TripId) : ICommand<Guid>;
}