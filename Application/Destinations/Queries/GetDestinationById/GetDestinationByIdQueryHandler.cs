using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Destinations.Dto;
using TravelBookManager.Application.Destinations.Mapper;
using TravelBookManager.Domain.Destinations.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Destinations.Queries.GetDestinationById
{
    public sealed class GetDestinationByIdQueryHandler : IQueryHandler<GetDestinationByIdQuery, DestinationDto>
    {
        private readonly IDestinationRepository _repo;

        public GetDestinationByIdQueryHandler(IDestinationRepository repo) => _repo = repo;

        public async Task<Result<DestinationDto>> Handle(GetDestinationByIdQuery request, CancellationToken cancellationToken)
        {
            var repoResult = await _repo.GetByIdAsync(request.Id);
            return repoResult.IsFailure ? Result.Failure<DestinationDto>(repoResult.Error) : Result.Success(repoResult.Value.ToDto());
        }
    }
}
