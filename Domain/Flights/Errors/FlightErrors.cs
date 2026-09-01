using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Flights.Errors
{
    public record FlightErrors : Error
    {
        public FlightErrors(string code, string description, ErrorType type) : base(code, description, type) { }

        public static Error EmptyDeparture = new Error("Flight.DepartureEmpty", "L'aeroporto di partenza non può essere vuoto", ErrorType.Problem);
        public static Error EmptyArrival = new Error("Flight.ArrivalEmpty", "L'aeroporto di arrivo non può essere vuoto", ErrorType.Problem);
        public static Error EmptyAirline = new Error("Flight.AirlineEmpty", "La compagnia di volo non può essere vuota", ErrorType.Problem);
        public static Error SameDepartureAndArrival = new Error("Flight.SameDepartureAndArrival", "L'aeroporto di partenza e di arrivo sono gli stessi", ErrorType.Conflict);
    }
}