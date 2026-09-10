using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Destinations.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Destinations.Commands.DeleteDestination
{
    public sealed class DeleteDestinationCommandHandler : ICommandHandler<DeleteDestinationCommand, Guid>
    {
        private readonly IDestinationRepository _repo;

        public DeleteDestinationCommandHandler(IDestinationRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(DeleteDestinationCommand request, CancellationToken cancellationToken)
        {
            var removeResult = await _repo.RemoveAsync(request.Id);
            return removeResult.IsFailure ? Result.Failure<Guid>(removeResult.Error) : Result.Success(request.Id);
        }
    }
}
