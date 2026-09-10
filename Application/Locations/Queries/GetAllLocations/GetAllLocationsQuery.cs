using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Locations.Dto;

namespace TravelBookManager.Application.Locations.Queries.GetAllLocations
{
    public sealed record GetAllLocationsQuery : IQuery<List<LocationDto>>;
}
