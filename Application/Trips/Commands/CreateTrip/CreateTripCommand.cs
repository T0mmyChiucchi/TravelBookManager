using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Trips.Commands.CreateTrip
{
    public sealed record CreateTripCommand(Guid UserId, string TripName) : ICommand<Guid>;
}