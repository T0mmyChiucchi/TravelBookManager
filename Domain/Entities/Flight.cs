using TravelBookManager.Domain.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Entities
{
    public class Flight : Entity
    {
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string Airline { get; set; }

        //Value objects
        public DateRange FlightDateRange { get; set; }
        public Price FlightPrice { get; set; }

        public Flight(string departure, string arrival, DateTime start, DateTime end, string airLine, string currency, decimal value)
        {
            DepartureAirport = departure;
            ArrivalAirport = arrival;
            Airline = airLine;
            FlightDateRange = DateRange.Create(start, end);
            FlightPrice = Price.Create(currency, value);
        }
    }
}