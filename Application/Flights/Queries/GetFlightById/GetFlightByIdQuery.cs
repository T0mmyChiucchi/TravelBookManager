using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Flights.Dto;

namespace TravelBookManager.Application.Flights.Queries.GetFlightById
{
    public sealed record GetFlightByIdQuery(Guid Id) : IQuery<FlightDto>;
}
