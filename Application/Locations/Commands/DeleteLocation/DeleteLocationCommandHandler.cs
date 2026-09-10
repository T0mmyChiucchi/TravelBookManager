using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Locations.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Locations.Commands.DeleteLocation
{
    public sealed class DeleteLocationCommandHandler : ICommandHandler<DeleteLocationCommand, Guid>
    {
        private readonly ILocationRepository _repo;

        public DeleteLocationCommandHandler(ILocationRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var removeResult = await _repo.RemoveAsync(request.Id);
            return removeResult.IsFailure ? Result.Failure<Guid>(removeResult.Error) : Result.Success(request.Id);
        }
    }
}
