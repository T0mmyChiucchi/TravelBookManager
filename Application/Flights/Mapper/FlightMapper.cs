using TravelBookManager.Application.Flights.Dto;
using TravelBookManager.Domain.Flights;

namespace TravelBookManager.Application.Flights.Mapper
{
    public static class FlightMapper
    {
        public static FlightDto ToDto(this Flight entity)
        {
            // TODO: Ensure mapping matches Domain properties once you finish the Domain part.
            return new FlightDto(entity.Id, default!, default!, default!, default!, default!, default!, default!); // Placeholder, fix after Domain
        }
    }
}
