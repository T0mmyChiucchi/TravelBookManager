namespace TravelBookManager.Domain.Trips.Services
{
    public interface ITripOptimizationService
    {
        Task<Trip> OptimizeRouteAsync(Trip trip);
    }
}