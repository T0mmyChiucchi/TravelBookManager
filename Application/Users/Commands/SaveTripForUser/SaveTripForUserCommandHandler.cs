using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Users.Commands.SaveTripForUser
{
    public sealed class SaveTripForUserCommandHandler : ICommandHandler<SaveTripForUserCommand, Guid>
    {
        private readonly IUserRepository _userRepo;
        private readonly ITripRepository _tripRepo;

        public SaveTripForUserCommandHandler(IUserRepository userRepo, ITripRepository tripRepo)
        {
            _userRepo = userRepo;
            _tripRepo = tripRepo;
        }

        public async Task<Result<Guid>> Handle(SaveTripForUserCommand request, CancellationToken cancellationToken)
        {
            var userResult = await _userRepo.GetByIdAsync(request.UserId);
            if (userResult.IsFailure) return Result.Failure<Guid>(userResult.Error);
            var tripResult = await _tripRepo.GetByIdAsync(request.TripId);
            if (tripResult.IsFailure) return Result.Failure<Guid>(tripResult.Error);
            var addResult = userResult.Value.AddItinerary(tripResult.Value);
            if (addResult.IsFailure) return Result<Guid>.ValidationFailure(addResult.Error);
            var updateResult = await _userRepo.UpdateAsync(userResult.Value);
            return updateResult.IsFailure ? Result.Failure<Guid>(updateResult.Error) : Result.Success(request.UserId);
        }
    }
}