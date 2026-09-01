using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Flights.Errors;
using TravelBookManager.Domain.Shared.ValueObjects;

namespace TravelBookManager.Domain.Flights
{
    public class Flight : Entity
    {
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string Airline { get; set; }

        //Value objects
        public DateRange FlightDateRange { get; set; }
        public Price FlightPrice { get; set; }

        private Flight(string departure, string arrival, DateRange dateRange, string airLine, Price price)
        {
            DepartureAirport = departure;
            ArrivalAirport = arrival;
            Airline = airLine;
            FlightDateRange = dateRange;
            FlightPrice = price;
        }

        public static Result<Flight> Create(string departure, string arrival, DateTime start, DateTime end, string airLine, string currency, decimal value)
        {
            if (string.IsNullOrWhiteSpace(departure))
                return Result<Flight>.ValidationFailure(FlightErrors.EmptyDeparture);
            if (string.IsNullOrWhiteSpace(arrival))
                return Result<Flight>.ValidationFailure(FlightErrors.EmptyArrival);
            var dateRangeResult = DateRange.Create(start, end);
            if (dateRangeResult.IsFailure)
                return Result<Flight>.ValidationFailure(dateRangeResult.Error);
            if (string.IsNullOrWhiteSpace(airLine))
                return Result<Flight>.ValidationFailure(FlightErrors.EmptyAirline);
            if (departure == arrival)
                return Result<Flight>.ValidationFailure(FlightErrors.SameDepartureAndArrival);
            var priceResult = Price.Create(currency, value);
            if (priceResult.IsFailure)
                return Result<Flight>.ValidationFailure(priceResult.Error);
            return Result.Success(new Flight(departure, arrival, dateRangeResult.Value, airLine, priceResult.Value));
        }
    }
}