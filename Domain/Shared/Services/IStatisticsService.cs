using TravelBookManager.Domain.Destinations;


namespace TravelBookManager.Domain.Shared.Services
{
    public interface IStatisticsService
    {
        Task<IEnumerable<Destination>> GetTopPopularDestinationsAsync(int count);
        Task<double> CalculatePopularityScoreAsync(Guid destinationId);
    }
}