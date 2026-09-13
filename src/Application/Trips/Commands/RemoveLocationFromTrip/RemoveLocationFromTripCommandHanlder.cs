using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Locations.Repositories;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Trips.Commands.RemoveLocationFromTrip
{
    public sealed class RemoveLocationFromTripCommandHandler : ICommandHandler<RemoveLocationFromTripCommand, Guid>
    {
        private readonly ITripRepository _tripRepo;
        private readonly ILocationRepository _locationRepo;

        public RemoveLocationFromTripCommandHandler(ITripRepository tripRepo, ILocationRepository locationRepo)
        {
            _tripRepo = tripRepo;
            _locationRepo = locationRepo;
        }

        public async Task<Result<Guid>> Handle(RemoveLocationFromTripCommand request, CancellationToken cancellationToken)
        {
            var tripResult = await _tripRepo.GetByIdAsync(request.TripId);
            if (tripResult.IsFailure) return Result.Failure<Guid>(tripResult.Error);
            var locationResult = await _locationRepo.GetByIdAsync(request.LocationId);
            if (locationResult.IsFailure) return Result.Failure<Guid>(locationResult.Error);
            var removeLocationResult = tripResult.Value.RemoveLocation(locationResult.Value);
            if (removeLocationResult.IsFailure) return Result<Guid>.ValidationFailure(removeLocationResult.Error);
            var updateResult = await _tripRepo.UpdateAsync(tripResult.Value);
            return updateResult.IsFailure ? Result.Failure<Guid>(updateResult.Error) : Result.Success(request.TripId);
        }
    }
}