using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Locations.Commands.CreateLocation
{
    public sealed record CreateLocationCommand(string Name, string Type, double Latitude, double Longitude) : ICommand<Guid>;
}
