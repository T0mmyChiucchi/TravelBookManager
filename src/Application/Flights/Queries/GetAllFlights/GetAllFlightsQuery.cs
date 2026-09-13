using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Flights.Dto;

namespace TravelBookManager.Application.Flights.Queries.GetAllFlights
{
    public sealed record GetAllFlightsQuery : IQuery<List<FlightDto>>;
}
