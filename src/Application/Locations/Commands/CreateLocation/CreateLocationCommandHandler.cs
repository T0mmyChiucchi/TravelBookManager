using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Locations;
using TravelBookManager.Domain.Locations.Repositories;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Locations.Commands.CreateLocation
{
    public sealed class CreateLocationCommandHandler : ICommandHandler<CreateLocationCommand, Guid>
    {
        private readonly ILocationRepository _repo;

        public CreateLocationCommandHandler(ILocationRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var nameResult = Name.Create(request.Name);
            if (nameResult.IsFailure) return Result.Failure<Guid>(nameResult.Error);

            var coordResult = Coordinates.Create(request.Latitude, request.Longitude);
            if (coordResult.IsFailure) return Result.Failure<Guid>(coordResult.Error);

            var type = Enum.Parse<LocationType>(request.Type);
            var entity = Location.Create(nameResult.Value, type, coordResult.Value);
            var addResult = await _repo.AddAsync(entity);
            return addResult.IsFailure ? Result.Failure<Guid>(addResult.Error) : Result.Success(entity.Id);
        }
    }
}
