using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Destinations.Commands.DeleteDestination
{
    public sealed record DeleteDestinationCommand(Guid Id) : ICommand<Guid>;
}
