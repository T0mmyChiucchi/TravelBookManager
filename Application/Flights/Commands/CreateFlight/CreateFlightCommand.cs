using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Flights.Commands.CreateFlight
{
    public sealed record CreateFlightCommand(string Departure, string Arrival, DateTime Start, DateTime End, string Airline, string Currency, decimal Value) : ICommand<Guid>;
}
