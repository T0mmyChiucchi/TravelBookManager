using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Users.Commands.RegisterUser
{
    public sealed record RegisterUserCommand(string Name, string Email, string Username, string Password) : ICommand<Guid>;
}