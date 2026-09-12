using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Flights.Commands.ChangeFlightRoute
{
    public sealed record ChangeFlightRouteCommand(Guid FlightId, string Departure, string Arrival) : ICommand<Guid>;
}
