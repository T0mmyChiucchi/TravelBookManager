using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Destinations;
using TravelBookManager.Domain.Destinations.Repositories;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Destinations.Commands.CreateDestination
{
    public sealed class CreateDestinationCommandHandler : ICommandHandler<CreateDestinationCommand, Guid>
    {
        private readonly IDestinationRepository _repo;

        public CreateDestinationCommandHandler(IDestinationRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(CreateDestinationCommand request, CancellationToken cancellationToken)
        {
            var entityResult = Destination.Create(new Name(request.Name), request.Country, request.Latitude, request.Longitude, request.PopularityScore);
            if (entityResult.IsFailure) return Result.Failure<Guid>(entityResult.Error);

            var addResult = await _repo.AddAsync(entityResult.Value);
            return addResult.IsFailure ? Result.Failure<Guid>(addResult.Error) : Result.Success(entityResult.Value.Id);
        }
    }
}
