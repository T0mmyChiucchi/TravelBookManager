using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Destinations.Commands.ChangeDestinationName
{
    public sealed record ChangeDestinationNameCommand(Guid DestinationId, string Name) : ICommand<Guid>;
}
