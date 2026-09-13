using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Trips.Dto;

namespace TravelBookManager.Application.Trips.Queries.GetAllTrips
{
    public sealed record GetAllTripsQuery : IQuery<List<TripDto>>;
}