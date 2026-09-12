using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Destinations.Commands.ChangeDestinationPopularity
{
    public sealed record ChangeDestinationPopularityCommand(Guid DestinationId, double Score) : ICommand<Guid>;
}
