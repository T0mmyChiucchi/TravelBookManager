using TravelBookManager.Application.Destinations.Dto;
using TravelBookManager.Domain.Destinations;

namespace TravelBookManager.Application.Destinations.Mapper
{
    public static class DestinationMapper
    {
        public static DestinationDto ToDto(this Destination entity)
        {
            return new DestinationDto(entity.Id, entity.Name.Text, entity.CountryName.Name, entity.GeoCoordinates.Latitude, entity.GeoCoordinates.Longitude, entity.PopularityScore.Value);
        }
    }
}
