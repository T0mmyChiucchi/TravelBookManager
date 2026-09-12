using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Destinations;
using TravelBookManager.Domain.Destinations.Repositories;
using TravelBookManager.Domain.Destinations.ValueObjects;
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
            var nameResult = Name.Create(request.Name);
            if (nameResult.IsFailure) return Result.Failure<Guid>(nameResult.Error);

            var countryResult = Country.Create(request.Country);
            if (countryResult.IsFailure) return Result.Failure<Guid>(countryResult.Error);

            var coordResult = Coordinates.Create(request.Latitude, request.Longitude);
            if (coordResult.IsFailure) return Result.Failure<Guid>(coordResult.Error);

            var scoreResult = PopularityScore.Create(request.PopularityScore);
            if (scoreResult.IsFailure) return Result.Failure<Guid>(scoreResult.Error);

            var entity = Destination.Create(nameResult.Value, countryResult.Value, coordResult.Value, scoreResult.Value);
            var addResult = await _repo.AddAsync(entity);
            return addResult.IsFailure ? Result.Failure<Guid>(addResult.Error) : Result.Success(entity.Id);
        }
    }
}
