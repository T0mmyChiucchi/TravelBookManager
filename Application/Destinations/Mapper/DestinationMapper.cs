using TravelBookManager.Application.Destinations.Dto;
using TravelBookManager.Domain.Destinations;

namespace TravelBookManager.Application.Destinations.Mapper
{
    public static class DestinationMapper
    {
        public static DestinationDto ToDto(this Destination entity)
        {
            // TODO: Ensure mapping matches Domain properties once you finish the Domain part.
            return new DestinationDto(entity.Id, default!, default!, default!, default!, default!, default!, default!); // Placeholder, fix after Domain
        }
    }
}
