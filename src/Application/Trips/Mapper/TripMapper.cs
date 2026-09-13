using TravelBookManager.Application.Trips.Dto;
using TravelBookManager.Domain.Trips;
using TravelBookManager.Application.Locations.Mapper;

namespace TravelBookManager.Application.Trips.Mapper
{
    public static class TripMapper
    {
        public static TripDto ToDto(this Trip trip)
        {
            return new TripDto(trip.Id, trip.Name.Text, trip.TripRouteInfo.OptimizedRoute, trip.TripRouteInfo.TotalDistance, trip.Locations.Select(l => l.ToDto()).ToList());
        }
    }
}