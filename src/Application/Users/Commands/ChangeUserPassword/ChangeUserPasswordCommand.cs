using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Users.Commands.ChangeUserPassword
{
    public sealed record ChangeUserPasswordCommand(Guid UserId, string NewPassword) : ICommand<Guid>;
}