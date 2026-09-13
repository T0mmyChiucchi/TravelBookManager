using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Destinations.Commands.CreateDestination
{
    public sealed record CreateDestinationCommand(string Name, string Country, double Latitude, double Longitude, double PopularityScore) : ICommand<Guid>;
}
