using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Trips.Commands.RemoveLocationFromTrip
{
    public sealed record RemoveLocationFromTripCommand(Guid TripId, Guid LocationId) : ICommand<Guid>;
}