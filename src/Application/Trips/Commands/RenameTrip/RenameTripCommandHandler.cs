using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Trips.Commands.RenameTrip
{
    public sealed class RenameTripCommandHandler : ICommandHandler<RenameTripCommand, Guid>
    {
        private readonly ITripRepository _repo;

        public RenameTripCommandHandler(ITripRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(RenameTripCommand request, CancellationToken cancellationToken)
        {
            var tripResult = await _repo.GetByIdAsync(request.TripId);
            if (tripResult.IsFailure) return Result.Failure<Guid>(tripResult.Error);

            var nameResult = Name.Create(request.Name);
            if (nameResult.IsFailure) return Result.Failure<Guid>(nameResult.Error);

            var renameResult = tripResult.Value.Rename(nameResult.Value);
            if (renameResult.IsFailure) return Result.Failure<Guid>(renameResult.Error);

            var repoUpdateResult = await _repo.UpdateAsync(tripResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.TripId);
        }
    }
}
