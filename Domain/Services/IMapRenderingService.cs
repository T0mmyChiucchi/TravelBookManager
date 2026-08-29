using TravelBookManager.Domain.Entities;

namespace TravelBookManager.Domain.Services
{
    public interface IMapRenderingService
    {
        Task<string> GenerateTripMapUrlAsync(Trip trip);
    }
}