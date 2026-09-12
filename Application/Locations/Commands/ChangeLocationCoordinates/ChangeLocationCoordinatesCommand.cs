using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Locations.Commands.ChangeLocationCoordinates
{
    public sealed record ChangeLocationCoordinatesCommand(Guid LocationId, double Latitude, double Longitude) : ICommand<Guid>;
}
