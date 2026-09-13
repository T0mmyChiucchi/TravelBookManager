using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Locations.Dto;
using TravelBookManager.Application.Locations.Mapper;
using TravelBookManager.Domain.Locations.Repositories;
using TravelBookManager.SharedKernel;
using System.Linq;

namespace TravelBookManager.Application.Locations.Queries.GetAllLocations
{
    public sealed class GetAllLocationsQueryHandler : IQueryHandler<GetAllLocationsQuery, List<LocationDto>>
    {
        private readonly ILocationRepository _repo;

        public GetAllLocationsQueryHandler(ILocationRepository repo) => _repo = repo;

        public async Task<Result<List<LocationDto>>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            var repoResult = await _repo.GetAllAsync();
            if (repoResult.IsFailure) return Result.Failure<List<LocationDto>>(repoResult.Error);
            var dtos = repoResult.Value.Select(e => e.ToDto()).ToList();
            return Result.Success(dtos);
        }
    }
}
