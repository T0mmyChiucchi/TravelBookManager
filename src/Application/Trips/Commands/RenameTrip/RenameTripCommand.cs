using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Trips.Commands.RenameTrip
{
    public sealed record RenameTripCommand(Guid TripId, string Name) : ICommand<Guid>;
}