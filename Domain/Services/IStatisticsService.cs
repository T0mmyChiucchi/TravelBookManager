using TravelBookManager.Domain.Entities;

namespace TravelBookManager.Domain.Services
{
    public interface IStatisticsService
    {
        Task<IEnumerable<Destination>> GetTopPopularDestinationsAsync(int count);
        Task<double> CalculatePopularityScoreAsync(Guid destinationId);
    }
}