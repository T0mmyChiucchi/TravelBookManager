using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Locations.Commands.DeleteLocation
{
    public sealed record DeleteLocationCommand(Guid Id) : ICommand<Guid>;
}
