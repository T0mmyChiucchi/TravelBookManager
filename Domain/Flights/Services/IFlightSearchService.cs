namespace TravelBookManager.Domain.Flights.Services
{
    public interface IFlightSearchService
    {
        Task<IEnumerable<Flight>> SearchFlightsAsync(string departureAirport, string arrivalAirport, DateTime startDate, DateTime endDate);
    }
}