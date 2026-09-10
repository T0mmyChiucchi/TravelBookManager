using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Locations.Dto;
using TravelBookManager.Application.Locations.Mapper;
using TravelBookManager.Domain.Locations.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Locations.Queries.GetLocationById
{
    public sealed class GetLocationByIdQueryHandler : IQueryHandler<GetLocationByIdQuery, LocationDto>
    {
        private readonly ILocationRepository _repo;

        public GetLocationByIdQueryHandler(ILocationRepository repo) => _repo = repo;

        public async Task<Result<LocationDto>> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var repoResult = await _repo.GetByIdAsync(request.Id);
            return repoResult.IsFailure ? Result.Failure<LocationDto>(repoResult.Error) : Result.Success(repoResult.Value.ToDto());
        }
    }
}
