using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.Domain.Trips.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Trips.Commands.UpdateTripRoute
{
    public sealed class UpdateTripRouteCommandHandler : ICommandHandler<UpdateTripRouteCommand, Guid>
    {
        private readonly ITripRepository _repo;

        public UpdateTripRouteCommandHandler(ITripRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(UpdateTripRouteCommand request, CancellationToken cancellationToken)
        {
            var tripResult = await _repo.GetByIdAsync(request.TripId);
            if (tripResult.IsFailure) return Result.Failure<Guid>(tripResult.Error);

            var routeResult = RouteInfo.Create(request.OptimizedRoute, request.TotalDistance);
            if (routeResult.IsFailure) return Result.Failure<Guid>(routeResult.Error);

            var updateResult = tripResult.Value.UpdateRoute(routeResult.Value);
            if (updateResult.IsFailure) return Result.Failure<Guid>(updateResult.Error);

            var repoUpdateResult = await _repo.UpdateAsync(tripResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.TripId);
        }
    }
}
