using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Flights.Commands.ChangeFlightPrice
{
    public sealed record ChangeFlightPriceCommand(Guid FlightId, string Currency, decimal Value) : ICommand<Guid>;
}
