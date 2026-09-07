using TravelBookManager.Domain.Trips.Errors;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Trips.ValueObjects
{
    public sealed record RouteInfo
    {
        public string OptimizedRoute { get; }
        public double TotalDistance { get; }

        private RouteInfo(string optimizedRoute, double totalDistance)
        {
            OptimizedRoute = optimizedRoute;
            TotalDistance = totalDistance;
        }

        public static Result<RouteInfo> Create(string optimizedRoute, double totalDistance)
        {
            if (string.IsNullOrWhiteSpace(optimizedRoute))
                return Result<RouteInfo>.ValidationFailure(TripErrors.InvalidRoute);
            if (totalDistance < 0)
                return Result<RouteInfo>.ValidationFailure(TripErrors.NegativeDistance);
            return Result.Success(new RouteInfo(optimizedRoute, totalDistance));
        }

        public static RouteInfo Empty() => new RouteInfo(string.Empty, 0.0);
    }
}