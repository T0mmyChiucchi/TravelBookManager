using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Users.Commands.ChangeUserEmail
{
    public sealed record ChangeUserEmailCommand(Guid Id, string NewEmail) : ICommand<Guid>;
}