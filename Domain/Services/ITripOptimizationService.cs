using TravelBookManager.Domain.Entities;

namespace TravelBookManager.Domain.Services
{
    public interface ITripOptimizationService
    {
        Task<Trip> OptimizeRouteAsync(Trip trip);
    }
}