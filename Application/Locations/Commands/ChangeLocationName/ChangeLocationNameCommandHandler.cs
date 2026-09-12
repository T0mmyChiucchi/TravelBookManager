using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Locations.Repositories;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Locations.Commands.ChangeLocationName
{
    public sealed class ChangeLocationNameCommandHandler : ICommandHandler<ChangeLocationNameCommand, Guid>
    {
        private readonly ILocationRepository _repo;

        public ChangeLocationNameCommandHandler(ILocationRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(ChangeLocationNameCommand request, CancellationToken cancellationToken)
        {
            var locationResult = await _repo.GetByIdAsync(request.LocationId);
            if (locationResult.IsFailure) return Result.Failure<Guid>(locationResult.Error);

            var nameResult = Name.Create(request.Name);
            if (nameResult.IsFailure) return Result.Failure<Guid>(nameResult.Error);

            locationResult.Value.ChangeName(nameResult.Value);
            var repoUpdateResult = await _repo.UpdateAsync(locationResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.LocationId);
        }
    }
}
