using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Flights.Repositories;
using TravelBookManager.Domain.Flights.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Flights.Commands.ChangeFlightSchedule
{
    public sealed class ChangeFlightScheduleCommandHandler : ICommandHandler<ChangeFlightScheduleCommand, Guid>
    {
        private readonly IFlightRepository _repo;

        public ChangeFlightScheduleCommandHandler(IFlightRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(ChangeFlightScheduleCommand request, CancellationToken cancellationToken)
        {
            var flightResult = await _repo.GetByIdAsync(request.FlightId);
            if (flightResult.IsFailure) return Result.Failure<Guid>(flightResult.Error);

            var dateResult = DateRange.Create(request.Start, request.End);
            if (dateResult.IsFailure) return Result.Failure<Guid>(dateResult.Error);

            flightResult.Value.ChangeSchedule(dateResult.Value);
            var repoUpdateResult = await _repo.UpdateAsync(flightResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.FlightId);
        }
    }
}
