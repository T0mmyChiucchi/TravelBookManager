using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Locations.Commands.ChangeLocationType
{
    public sealed record ChangeLocationTypeCommand(Guid LocationId, string Type) : ICommand<Guid>;
}
