using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Flights.Repositories;
using TravelBookManager.Domain.Flights.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Flights.Commands.ChangeFlightRoute
{
    public sealed class ChangeFlightRouteCommandHandler : ICommandHandler<ChangeFlightRouteCommand, Guid>
    {
        private readonly IFlightRepository _repo;

        public ChangeFlightRouteCommandHandler(IFlightRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(ChangeFlightRouteCommand request, CancellationToken cancellationToken)
        {
            var flightResult = await _repo.GetByIdAsync(request.FlightId);
            if (flightResult.IsFailure) return Result.Failure<Guid>(flightResult.Error);

            var departureResult = Airport.Create(request.Departure);
            if (departureResult.IsFailure) return Result.Failure<Guid>(departureResult.Error);

            var arrivalResult = Airport.Create(request.Arrival);
            if (arrivalResult.IsFailure) return Result.Failure<Guid>(arrivalResult.Error);

            var updateResult = flightResult.Value.ChangeRoute(departureResult.Value, arrivalResult.Value);
            if (updateResult.IsFailure) return Result.Failure<Guid>(updateResult.Error);

            var repoUpdateResult = await _repo.UpdateAsync(flightResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.FlightId);
        }
    }
}
