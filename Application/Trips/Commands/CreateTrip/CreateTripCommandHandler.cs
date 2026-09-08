using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Domain.Trips;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Trips.Commands.CreateTrip
{
    public sealed class CreateTripCommandHandler : ICommandHandler<CreateTripCommand, Guid>
    {
        private readonly ITripRepository _tripRepo;
        private readonly IUserRepository _userRepo;

        public CreateTripCommandHandler(ITripRepository tripRepo, IUserRepository userRepo)
        {
            _tripRepo = tripRepo;
            _userRepo = userRepo;
        }
        public async Task<Result<Guid>> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var nameResult = Name.Create(request.TripName);
            if (nameResult.IsFailure) return Result<Guid>.ValidationFailure(nameResult.Error);
            var tripCreateResult = Trip.Create(nameResult.Value);
            if (tripCreateResult.IsFailure) return Result.Failure<Guid>(tripCreateResult.Error);
            var userResult = await _userRepo.GetByIdAsync(request.UserId);
            if (userResult.IsFailure) return Result.Failure<Guid>(userResult.Error);
            var addTripResult = userResult.Value.AddItinerary(tripCreateResult.Value);
            if (addTripResult.IsFailure) return Result<Guid>.ValidationFailure(addTripResult.Error);
            var repoResult = await _tripRepo.AddAsync(tripCreateResult.Value);
            if (repoResult.IsFailure) return Result.Failure<Guid>(repoResult.Error);
            var updateUserResult = await _userRepo.UpdateAsync(userResult.Value);
            return updateUserResult.IsFailure ? Result.Failure<Guid>(updateUserResult.Error) : Result.Success(tripCreateResult.Value.Id);
        }
    }
}