using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Trips.Dto;
using TravelBookManager.Application.Trips.Mapper;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Trips.Queries.GetAllTrips
{
    public sealed class GetAllTripsQueryHandler : IQueryHandler<GetAllTripsQuery, List<TripDto>>
    {
        private readonly ITripRepository _repo;

        public GetAllTripsQueryHandler(ITripRepository repo) => _repo = repo;

        public async Task<Result<List<TripDto>>> Handle(GetAllTripsQuery request, CancellationToken cancellationToken)
        {
            var repoResult = await _repo.GetAllAsync();
            if (repoResult.IsFailure) return Result.Failure<List<TripDto>>(repoResult.Error);
            var dtos = repoResult.Value.Select(trip => trip.ToDto()).ToList();
            return Result.Success(dtos);
        }
    }
}