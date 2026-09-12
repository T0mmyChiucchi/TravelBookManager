using TravelBookManager.Application.Abstractions;

namespace TravelBookManager.Application.Destinations.Commands.ChangeDestinationCountry
{
    public sealed record ChangeDestinationCountryCommand(Guid DestinationId, string Country) : ICommand<Guid>;
}
