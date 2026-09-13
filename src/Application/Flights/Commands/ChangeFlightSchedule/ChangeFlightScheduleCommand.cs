using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Flights.Commands.ChangeFlightSchedule
{
    public sealed record ChangeFlightScheduleCommand(Guid FlightId, DateTime Start, DateTime End) : ICommand<Guid>;
}
