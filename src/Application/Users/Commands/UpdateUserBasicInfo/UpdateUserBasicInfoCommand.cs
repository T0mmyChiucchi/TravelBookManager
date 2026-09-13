using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Users.Commands.UpdateUserBasicInfo
{
    public sealed record UpdateUserBasicInfoCommand(Guid UserId, string Name, string Username) : ICommand<Guid>;
}