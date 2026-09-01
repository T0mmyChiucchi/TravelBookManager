using TravelBookManager.Domain.Trips;


namespace TravelBookManager.Domain.Shared.Services
{
    public interface IMapRenderingService
    {
        Task<string> GenerateTripMapUrlAsync(Trip trip);
    }
}