using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Trips.Dto;

namespace TravelBookManager.Application.Trips.Queries.GetTripById
{
    public sealed record GetTripByIdQuery(Guid Id) : IQuery<TripDto>;
}