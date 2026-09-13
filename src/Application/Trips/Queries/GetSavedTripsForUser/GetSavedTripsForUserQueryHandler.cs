using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Trips.Dto;
using TravelBookManager.Application.Trips.Mapper;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Trips.Queries.GetSavedTripsForUser
{
    public sealed class GetSavedTripsForUserQueryHandler : IQueryHandler<GetSavedTripsForUserQuery, List<TripDto>>
    {
        private readonly IUserRepository _repo;

        public GetSavedTripsForUserQueryHandler(IUserRepository repo) => _repo = repo;

        public async Task<Result<List<TripDto>>> Handle(GetSavedTripsForUserQuery request, CancellationToken cancellationToken)
        {
            var userResult = await _repo.GetByIdAsync(request.UserId);
            if (userResult.IsFailure) return Result.Failure<List<TripDto>>(userResult.Error);
            var dtos = userResult.Value.SavedTrips.Select(trip => trip.ToDto()).ToList();
            return Result.Success(dtos);
        }
    }
}