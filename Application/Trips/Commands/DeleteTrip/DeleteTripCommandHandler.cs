using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Trips.Commands.DeleteTrip
{
    public sealed class DeleteTripCommandHandler : ICommandHandler<DeleteTripCommand, Guid>
    {
        private readonly ITripRepository _tripRepo;
        private readonly IUserRepository _userRepo;

        public DeleteTripCommandHandler(ITripRepository tripRepo, IUserRepository userRepo)
        {
            _tripRepo = tripRepo;
            _userRepo = userRepo;
        }
        public async Task<Result<Guid>> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var tripResult = await _tripRepo.GetByIdAsync(request.TripId);
            if (tripResult.IsFailure) return Result.Failure<Guid>(tripResult.Error);
            var userResult = await _userRepo.GetByIdAsync(request.UserId);
            if (userResult.IsFailure) return Result.Failure<Guid>(userResult.Error);
            var removeTripResult = userResult.Value.RemoveItinerary(tripResult.Value);
            if (removeTripResult.IsFailure) return Result<Guid>.ValidationFailure(removeTripResult.Error);
            var repoResult = await _tripRepo.RemoveAsync(tripResult.Value.Id);
            if (repoResult.IsFailure) return Result.Failure<Guid>(repoResult.Error);
            var updateUserResult = await _userRepo.UpdateAsync(userResult.Value);
            return updateUserResult.IsFailure ? Result.Failure<Guid>(updateUserResult.Error) : Result.Success(request.TripId);
        }
    }
}