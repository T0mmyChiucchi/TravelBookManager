using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Trips.Commands.DeleteTrip
{
    public sealed record DeleteTripCommand(Guid UserId, Guid TripId) : ICommand<Guid>;
}