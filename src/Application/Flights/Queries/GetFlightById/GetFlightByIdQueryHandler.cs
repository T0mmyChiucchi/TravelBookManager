using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Flights.Dto;
using TravelBookManager.Application.Flights.Mapper;
using TravelBookManager.Domain.Flights.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Flights.Queries.GetFlightById
{
    public sealed class GetFlightByIdQueryHandler : IQueryHandler<GetFlightByIdQuery, FlightDto>
    {
        private readonly IFlightRepository _repo;

        public GetFlightByIdQueryHandler(IFlightRepository repo) => _repo = repo;

        public async Task<Result<FlightDto>> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
        {
            var repoResult = await _repo.GetByIdAsync(request.Id);
            return repoResult.IsFailure ? Result.Failure<FlightDto>(repoResult.Error) : Result.Success(repoResult.Value.ToDto());
        }
    }
}
