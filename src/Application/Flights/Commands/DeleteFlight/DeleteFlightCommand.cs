using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Flights.Commands.DeleteFlight
{
    public sealed record DeleteFlightCommand(Guid Id) : ICommand<Guid>;
}
