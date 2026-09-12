using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Destinations.Repositories;
using TravelBookManager.Domain.Destinations.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Destinations.Commands.ChangeDestinationCountry
{
    public sealed class ChangeDestinationCountryCommandHandler : ICommandHandler<ChangeDestinationCountryCommand, Guid>
    {
        private readonly IDestinationRepository _repo;

        public ChangeDestinationCountryCommandHandler(IDestinationRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(ChangeDestinationCountryCommand request, CancellationToken cancellationToken)
        {
            var destinationResult = await _repo.GetByIdAsync(request.DestinationId);
            if (destinationResult.IsFailure) return Result.Failure<Guid>(destinationResult.Error);

            var countryResult = Country.Create(request.Country);
            if (countryResult.IsFailure) return Result.Failure<Guid>(countryResult.Error);

            destinationResult.Value.ChangeCountry(countryResult.Value);
            var repoUpdateResult = await _repo.UpdateAsync(destinationResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.DestinationId);
        }
    }
}
