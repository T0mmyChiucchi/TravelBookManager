namespace TravelBookManager.Domain.Trips.Services
{
    public interface IMapRenderingService
    {
        Task<string> GenerateTripMapUrlAsync(Trip trip);
    }
}