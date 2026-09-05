using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Users.Commands.RemoveTripFromUser;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Users.Commands.RemoveTripFromUser
{
    public sealed class RemoveTripFromUserCommandHandler : ICommandHandler<RemoveTripFromUserCommand, Guid>
    {
        private readonly IUserRepository _userRepo;
        private readonly ITripRepository _tripRepo;

        public RemoveTripFromUserCommandHandler(IUserRepository userRepo, ITripRepository tripRepo)
        {
            _userRepo = userRepo;
            _tripRepo = tripRepo;
        }

        public async Task<Result<Guid>> Handle(RemoveTripFromUserCommand request, CancellationToken cancellationToken)
        {
            var userResult = await _userRepo.GetByIdAsync(request.UserId);
            if (userResult.IsFailure) return Result.Failure<Guid>(userResult.Error);
            var tripResult = await _tripRepo.GetByIdAsync(request.TripId);
            if (tripResult.IsFailure) return Result.Failure<Guid>(tripResult.Error);
            var removeResult = userResult.Value.RemoveItinerary(tripResult.Value);
            if (removeResult.IsFailure) return Result<Guid>.ValidationFailure(removeResult.Error);
            var updateResult = await _userRepo.UpdateAsync(userResult.Value);
            return updateResult.IsFailure ? Result.Failure<Guid>(updateResult.Error) : Result.Success(request.UserId);
        }
    }
}