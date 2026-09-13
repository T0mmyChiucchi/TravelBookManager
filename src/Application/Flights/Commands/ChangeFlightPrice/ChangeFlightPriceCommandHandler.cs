using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Flights.Repositories;
using TravelBookManager.Domain.Flights.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Flights.Commands.ChangeFlightPrice
{
    public sealed class ChangeFlightPriceCommandHandler : ICommandHandler<ChangeFlightPriceCommand, Guid>
    {
        private readonly IFlightRepository _repo;

        public ChangeFlightPriceCommandHandler(IFlightRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(ChangeFlightPriceCommand request, CancellationToken cancellationToken)
        {
            var flightResult = await _repo.GetByIdAsync(request.FlightId);
            if (flightResult.IsFailure) return Result.Failure<Guid>(flightResult.Error);

            var priceResult = Price.Create(request.Currency, request.Value);
            if (priceResult.IsFailure) return Result.Failure<Guid>(priceResult.Error);

            flightResult.Value.ChangePrice(priceResult.Value);
            var repoUpdateResult = await _repo.UpdateAsync(flightResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.FlightId);
        }
    }
}
