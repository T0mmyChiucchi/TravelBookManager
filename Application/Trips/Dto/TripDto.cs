using TravelBookManager.Application.Locations.Dto;

namespace TravelBookManager.Application.Trips.Dto
{
    public sealed record TripDto(Guid Id, string Name, string OptimizedRoute, double TotalDistance, List<LocationDto> Locations);
}