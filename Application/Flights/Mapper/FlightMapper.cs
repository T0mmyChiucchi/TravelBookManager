using TravelBookManager.Application.Flights.Dto;
using TravelBookManager.Domain.Flights;

namespace TravelBookManager.Application.Flights.Mapper
{
    public static class FlightMapper
    {
        public static FlightDto ToDto(this Flight entity)
        {
            return new FlightDto(entity.Id, entity.DepartureAirport.AirportName, entity.ArrivalAirport.AirportName, entity.Airline.AirLineName, entity.FlightDateRange.StartDate, entity.FlightDateRange.EndDate, entity.FlightPrice.Currency, entity.FlightPrice.Value);
        }
    }
}
