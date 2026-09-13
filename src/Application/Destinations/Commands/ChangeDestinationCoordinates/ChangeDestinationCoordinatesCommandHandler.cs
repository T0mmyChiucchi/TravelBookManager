using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Destinations.Repositories;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Destinations.Commands.ChangeDestinationCoordinates
{
    public sealed class ChangeDestinationCoordinatesCommandHandler : ICommandHandler<ChangeDestinationCoordinatesCommand, Guid>
    {
        private readonly IDestinationRepository _repo;

        public ChangeDestinationCoordinatesCommandHandler(IDestinationRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(ChangeDestinationCoordinatesCommand request, CancellationToken cancellationToken)
        {
            var destinationResult = await _repo.GetByIdAsync(request.DestinationId);
            if (destinationResult.IsFailure) return Result.Failure<Guid>(destinationResult.Error);

            var coordResult = Coordinates.Create(request.Latitude, request.Longitude);
            if (coordResult.IsFailure) return Result.Failure<Guid>(coordResult.Error);

            destinationResult.Value.ChangeCoordinates(coordResult.Value);
            var repoUpdateResult = await _repo.UpdateAsync(destinationResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.DestinationId);
        }
    }
}
