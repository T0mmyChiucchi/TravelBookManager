using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Trips;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Trips.Commands.CreateTrip
{
    public sealed class CreateTripCommandHandler : ICommandHandler<CreateTripCommand, Guid>
    {
        private readonly ITripRepository _repo;

        public CreateTripCommandHandler(ITripRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var nameResult = Name.Create(request.TripName);
            if (nameResult.IsFailure) return Result.Failure<Guid>(nameResult.Error);

            var entity = Trip.Create(nameResult.Value);
            var addResult = await _repo.AddAsync(entity);
            return addResult.IsFailure ? Result.Failure<Guid>(addResult.Error) : Result.Success(entity.Id);
        }
    }
}
