using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Locations.Repositories;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Trips.Commands.AddLocationToTrip
{
    public sealed class AddLocationToTripCommandHandler : ICommandHandler<AddLocationToTripCommand, Guid>
    {
        private readonly ITripRepository _tripRepo;
        private readonly ILocationRepository _locationRepo;

        public AddLocationToTripCommandHandler(ITripRepository tripRepo, ILocationRepository locationRepo)
        {
            _tripRepo = tripRepo;
            _locationRepo = locationRepo;
        }

        public async Task<Result<Guid>> Handle(AddLocationToTripCommand request, CancellationToken cancellationToken)
        {
            var tripResult = await _tripRepo.GetByIdAsync(request.TripId);
            if (tripResult.IsFailure) return Result.Failure<Guid>(tripResult.Error);
            var locationResult = await _locationRepo.GetByIdAsync(request.LocationId);
            if (locationResult.IsFailure) return Result.Failure<Guid>(locationResult.Error);
            var addResult = tripResult.Value.AddLocation(locationResult.Value);
            if (addResult.IsFailure) return Result<Guid>.ValidationFailure(addResult.Error);
            var updateResult = await _tripRepo.UpdateAsync(tripResult.Value);
            return updateResult.IsFailure ? Result.Failure<Guid>(updateResult.Error) : Result.Success(request.TripId);
        }
    }
}