using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Destinations.Commands.ChangeDestinationCoordinates
{
    public sealed record ChangeDestinationCoordinatesCommand(Guid DestinationId, double Latitude, double Longitude) : ICommand<Guid>;
}
