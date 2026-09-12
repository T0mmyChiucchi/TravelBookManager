using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Flights;
using TravelBookManager.Domain.Flights.Repositories;
using TravelBookManager.Domain.Flights.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Flights.Commands.CreateFlight
{
    public sealed class CreateFlightCommandHandler : ICommandHandler<CreateFlightCommand, Guid>
    {
        private readonly IFlightRepository _repo;

        public CreateFlightCommandHandler(IFlightRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var departureResult = Airport.Create(request.Departure);
            if (departureResult.IsFailure) return Result.Failure<Guid>(departureResult.Error);

            var arrivalResult = Airport.Create(request.Arrival);
            if (arrivalResult.IsFailure) return Result.Failure<Guid>(arrivalResult.Error);

            var dateResult = DateRange.Create(request.Start, request.End);
            if (dateResult.IsFailure) return Result.Failure<Guid>(dateResult.Error);

            var airlineResult = Airline.Create(request.Airline);
            if (airlineResult.IsFailure) return Result.Failure<Guid>(airlineResult.Error);

            var priceResult = Price.Create(request.Currency, request.Value);
            if (priceResult.IsFailure) return Result.Failure<Guid>(priceResult.Error);

            var flightResult = Flight.Create(departureResult.Value, arrivalResult.Value, dateResult.Value, airlineResult.Value, priceResult.Value);
            if (flightResult.IsFailure) return Result.Failure<Guid>(flightResult.Error);

            var addResult = await _repo.AddAsync(flightResult.Value);
            return addResult.IsFailure ? Result.Failure<Guid>(addResult.Error) : Result.Success(flightResult.Value.Id);
        }
    }
}
