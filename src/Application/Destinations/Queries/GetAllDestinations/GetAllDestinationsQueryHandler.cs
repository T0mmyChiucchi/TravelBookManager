using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Destinations.Dto;
using TravelBookManager.Application.Destinations.Mapper;
using TravelBookManager.Domain.Destinations.Repositories;
using TravelBookManager.SharedKernel;
using System.Linq;

namespace TravelBookManager.Application.Destinations.Queries.GetAllDestinations
{
    public sealed class GetAllDestinationsQueryHandler : IQueryHandler<GetAllDestinationsQuery, List<DestinationDto>>
    {
        private readonly IDestinationRepository _repo;

        public GetAllDestinationsQueryHandler(IDestinationRepository repo) => _repo = repo;

        public async Task<Result<List<DestinationDto>>> Handle(GetAllDestinationsQuery request, CancellationToken cancellationToken)
        {
            var repoResult = await _repo.GetAllAsync();
            if (repoResult.IsFailure) return Result.Failure<List<DestinationDto>>(repoResult.Error);
            var dtos = repoResult.Value.Select(e => e.ToDto()).ToList();
            return Result.Success(dtos);
        }
    }
}
