using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Trips.Commands.RenameTrip
{
    public sealed class RenameTripCommandHandler : ICommandHandler<RenameTripCommand, Guid>
    {
        private readonly ITripRepository _repo;

        public RenameTripCommandHandler(ITripRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(RenameTripCommand request, CancellationToken cancellationToken)
        {
            var tripResult = await _repo.GetByIdAsync(request.Id);
            if (tripResult.IsFailure) return Result.Failure<Guid>(tripResult.Error);
            var nameResult = Name.Create(request.NewName);
            if (nameResult.IsFailure) return Result<Guid>.ValidationFailure(nameResult.Error);
            var renameResult = tripResult.Value.Rename(nameResult.Value);
            if (renameResult.IsFailure) return Result.Failure<Guid>(renameResult.Error);
            var updateResult = await _repo.UpdateAsync(tripResult.Value);
            return updateResult.IsFailure ? Result.Failure<Guid>(updateResult.Error) : Result.Success(request.Id);
        }
    }
}