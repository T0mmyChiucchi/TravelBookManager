using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Trips.Commands.AddLocationToTrip
{
    public sealed record AddLocationToTripCommand(Guid TripId, Guid LocationId) : ICommand<Guid>;
}