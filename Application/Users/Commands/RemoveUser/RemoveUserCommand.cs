using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Users.Commands.RemoveUser
{
    public sealed record RemoveUserCommand(Guid Id) : ICommand<Guid>;
}