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
            var entityResult = Location.Create(new Name(request.Name), Enum.Parse<LocationType>(request.Type), request.Latitude, request.Longitude);
            if (entityResult.IsFailure) return Result.Failure<Guid>(entityResult.Error);

            var addResult = await _repo.AddAsync(entityResult.Value);
            return addResult.IsFailure ? Result.Failure<Guid>(addResult.Error) : Result.Success(entityResult.Value.Id);
        }
    }
}
