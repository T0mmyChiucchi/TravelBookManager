using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Flights;
using TravelBookManager.Domain.Flights.Repositories;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Flights.Commands.CreateFlight
{
    public sealed class CreateFlightCommandHandler : ICommandHandler<CreateFlightCommand, Guid>
    {
        private readonly IFlightRepository _repo;

        public CreateFlightCommandHandler(IFlightRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var entityResult = Flight.Create(request.Departure, request.Arrival, request.Start, request.End, request.Airline, request.Currency, request.Value);
            if (entityResult.IsFailure) return Result.Failure<Guid>(entityResult.Error);

            var addResult = await _repo.AddAsync(entityResult.Value);
            return addResult.IsFailure ? Result.Failure<Guid>(addResult.Error) : Result.Success(entityResult.Value.Id);
        }
    }
}
