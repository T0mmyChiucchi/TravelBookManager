using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Trips.Dto;
using TravelBookManager.Application.Trips.Mapper;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Trips.Queries.GetTripById
{
    public sealed class GetTripByIdQueryHandler : IQueryHandler<GetTripByIdQuery, TripDto>
    {
        private readonly ITripRepository _repo;

        public GetTripByIdQueryHandler(ITripRepository repo) => _repo = repo;

        public async Task<Result<TripDto>> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
        {
            var tripResult = await _repo.GetByIdAsync(request.Id);
            return tripResult.IsFailure ? Result.Failure<TripDto>(tripResult.Error) : Result.Success(tripResult.Value.ToDto());
        }
    }
}