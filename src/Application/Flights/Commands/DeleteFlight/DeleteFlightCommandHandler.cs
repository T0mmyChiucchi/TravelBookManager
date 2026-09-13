using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Flights.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Flights.Commands.DeleteFlight
{
    public sealed class DeleteFlightCommandHandler : ICommandHandler<DeleteFlightCommand, Guid>
    {
        private readonly IFlightRepository _repo;

        public DeleteFlightCommandHandler(IFlightRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            var removeResult = await _repo.RemoveAsync(request.Id);
            return removeResult.IsFailure ? Result.Failure<Guid>(removeResult.Error) : Result.Success(request.Id);
        }
    }
}
