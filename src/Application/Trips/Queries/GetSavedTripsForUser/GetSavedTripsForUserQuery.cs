using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Trips.Dto;

namespace TravelBookManager.Application.Trips.Queries.GetSavedTripsForUser
{
    public sealed record GetSavedTripsForUserQuery(Guid UserId) : IQuery<List<TripDto>>;
}