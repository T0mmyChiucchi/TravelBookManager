using TravelBookManager.Application.Locations.Dto;
using TravelBookManager.Domain.Locations;

namespace TravelBookManager.Application.Locations.Mapper
{
    public static class LocationMapper
    {
        public static LocationDto ToDto(this Location location)
        {
            return new LocationDto(location.Id, location.Name.Text, location.Type.ToString(), location.GeoCoordinates.Latitude, location.GeoCoordinates.Longitude);
        }
    }
}