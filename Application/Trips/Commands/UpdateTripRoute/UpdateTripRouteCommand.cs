using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Trips.Commands.UpdateTripRoute
{
    public sealed record UpdateTripRouteCommand(Guid TripId, string OptimizedRoute, double TotalDistance) : ICommand<Guid>;
}
