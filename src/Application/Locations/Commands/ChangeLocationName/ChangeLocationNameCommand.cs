using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Locations.Commands.ChangeLocationName
{
    public sealed record ChangeLocationNameCommand(Guid LocationId, string Name) : ICommand<Guid>;
}
