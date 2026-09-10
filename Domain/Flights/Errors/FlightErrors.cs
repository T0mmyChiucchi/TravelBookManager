using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Flights.Errors
{
    public record FlightErrors : Error
    {
        public FlightErrors(string code, string description, ErrorType type) : base(code, description, type) { }

        public static Error EmptyAirport = new Error("Airport.AirportEmpty", "L'aeroporto non può essere vuoto", ErrorType.Validation);
        public static Error InvalidAirportLength = new Error("Airport.AirportInvalidLength", "La lunghezza del nome dell'aeroporto non è valida", ErrorType.Validation);

        public static Error EmptyAirline = new Error("Airline.AirlineEmpty", "La compagnia di volo non può essere vuota", ErrorType.Validation);
        public static Error InvalidAirlineLength = new Error("Airline.AirlineInvalidLength", "La lunghezza della compagnia di volo non è valida", ErrorType.Validation);

        public static Error NegativeValue = new Error("Price.NegativeValue", "Il valore del prezzo non può essere negativo", ErrorType.Validation);
        public static Error EmptyCurrency = new Error("Price.CurrencyEmpty", "La valuta non può essere vuota", ErrorType.Validation);

        public static Error EndDateBeforeStartDate = new Error("DateRange.EndDateBeforeStartDate", "La data di fine non può essere precedente alla data di inizio", ErrorType.Validation);

        public static Error SameDepartureAndArrival = new Error("Flight.SameDepartureAndArrival", "L'aeroporto di partenza e di arrivo sono gli stessi", ErrorType.Conflict);
    }
}