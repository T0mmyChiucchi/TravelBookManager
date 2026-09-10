using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Flights.Errors;
using TravelBookManager.Domain.Flights.ValueObjects;

namespace TravelBookManager.Domain.Flights
{
    public sealed class Flight : Entity
    {
        public Airport DepartureAirport { get; private set; }
        public Airport ArrivalAirport { get; private set; }
        public DateRange FlightDateRange { get; private set; }
        public Airline Airline { get; private set; }
        public Price FlightPrice { get; private set; }

        private Flight(Airport departure, Airport arrival, DateRange dateRange, Airline airLine, Price price)
        {
            DepartureAirport = departure;
            ArrivalAirport = arrival;
            Airline = airLine;
            FlightDateRange = dateRange;
            FlightPrice = price;
        }

        public static Result<Flight> Create(Airport departure, Airport arrival, DateRange dateRange, Airline airLine, Price price)
        {
            if (departure == arrival)
                return Result<Flight>.ValidationFailure(FlightErrors.SameDepartureAndArrival);
            return Result.Success(new Flight(departure, arrival, dateRange, airLine, price));
        }

        public void ChangeSchedule(DateRange newSchedule) => FlightDateRange = newSchedule;

        public void ChangePrice(Price newPrice) => FlightPrice = newPrice;

        public Result ChangeRoute(Airport newDeparture, Airport newArrival)
        {
            if (newDeparture == newArrival)
                return Result.Failure(FlightErrors.SameDepartureAndArrival);
            DepartureAirport = newDeparture;
            ArrivalAirport = newArrival;
            return Result.Success();
        }
    }
}