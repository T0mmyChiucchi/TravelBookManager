using TravelBookManager.Domain.Entities;

namespace TravelBookManager.Domain.Services
{
    public interface IFlightSearchService
    {
        Task<IEnumerable<Flight>> SearchFlightsAsync(string departureAirport, string arrivalAirport, DateTime startDate, DateTime endDate);
    }
}