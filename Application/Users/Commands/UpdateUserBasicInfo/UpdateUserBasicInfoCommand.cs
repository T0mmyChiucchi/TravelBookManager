using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Users.Commands.UpdateUserBasicInfo
{
    public sealed record UpdateUserBasicInfoCommand(Guid Id, string NewName, string NewUsername) : ICommand<Guid>;
}