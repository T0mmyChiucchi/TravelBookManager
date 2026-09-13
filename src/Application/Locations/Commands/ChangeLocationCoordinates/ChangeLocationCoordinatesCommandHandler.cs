using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Locations.Repositories;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Locations.Commands.ChangeLocationCoordinates
{
    public sealed class ChangeLocationCoordinatesCommandHandler : ICommandHandler<ChangeLocationCoordinatesCommand, Guid>
    {
        private readonly ILocationRepository _repo;

        public ChangeLocationCoordinatesCommandHandler(ILocationRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(ChangeLocationCoordinatesCommand request, CancellationToken cancellationToken)
        {
            var locationResult = await _repo.GetByIdAsync(request.LocationId);
            if (locationResult.IsFailure) return Result.Failure<Guid>(locationResult.Error);

            var coordResult = Coordinates.Create(request.Latitude, request.Longitude);
            if (coordResult.IsFailure) return Result.Failure<Guid>(coordResult.Error);

            locationResult.Value.ChangeCoordinates(coordResult.Value);
            var repoUpdateResult = await _repo.UpdateAsync(locationResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.LocationId);
        }
    }
}
