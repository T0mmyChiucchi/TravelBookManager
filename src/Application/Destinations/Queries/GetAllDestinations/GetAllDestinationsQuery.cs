using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Destinations.Dto;

namespace TravelBookManager.Application.Destinations.Queries.GetAllDestinations
{
    public sealed record GetAllDestinationsQuery : IQuery<List<DestinationDto>>;
}
