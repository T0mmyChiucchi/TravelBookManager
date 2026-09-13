using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Destinations.Repositories;
using TravelBookManager.Domain.Destinations.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Destinations.Commands.ChangeDestinationPopularity
{
    public sealed class ChangeDestinationPopularityCommandHandler : ICommandHandler<ChangeDestinationPopularityCommand, Guid>
    {
        private readonly IDestinationRepository _repo;

        public ChangeDestinationPopularityCommandHandler(IDestinationRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(ChangeDestinationPopularityCommand request, CancellationToken cancellationToken)
        {
            var destinationResult = await _repo.GetByIdAsync(request.DestinationId);
            if (destinationResult.IsFailure) return Result.Failure<Guid>(destinationResult.Error);

            var scoreResult = PopularityScore.Create(request.Score);
            if (scoreResult.IsFailure) return Result.Failure<Guid>(scoreResult.Error);

            destinationResult.Value.ChangePopularity(scoreResult.Value);
            var repoUpdateResult = await _repo.UpdateAsync(destinationResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.DestinationId);
        }
    }
}
