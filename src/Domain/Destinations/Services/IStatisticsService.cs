namespace TravelBookManager.Domain.Destinations.Services
{
    public interface IStatisticsService
    {
        Task<IEnumerable<Destination>> GetTopPopularDestinationsAsync(int count);
        Task<double> CalculatePopularityScoreAsync(Guid destinationId);
    }
}