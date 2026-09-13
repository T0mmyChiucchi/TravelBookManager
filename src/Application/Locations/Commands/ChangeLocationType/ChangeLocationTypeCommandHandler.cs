using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Locations;
using TravelBookManager.Domain.Locations.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Locations.Commands.ChangeLocationType
{
    public sealed class ChangeLocationTypeCommandHandler : ICommandHandler<ChangeLocationTypeCommand, Guid>
    {
        private readonly ILocationRepository _repo;

        public ChangeLocationTypeCommandHandler(ILocationRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(ChangeLocationTypeCommand request, CancellationToken cancellationToken)
        {
            var locationResult = await _repo.GetByIdAsync(request.LocationId);
            if (locationResult.IsFailure) return Result.Failure<Guid>(locationResult.Error);

            var type = Enum.Parse<LocationType>(request.Type);
            locationResult.Value.ChangeType(type);
            var repoUpdateResult = await _repo.UpdateAsync(locationResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.LocationId);
        }
    }
}
