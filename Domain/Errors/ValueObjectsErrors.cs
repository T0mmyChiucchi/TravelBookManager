using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Errors
{
    public record ValueObjectsErrors : Error
    {
        public ValueObjectsErrors(string code, string description, ErrorType type) : base(code, description, type) { }

        public static Error NegativeValue = new Error("Price.NegativeValue", "Il valore del prezzo non può essere negativo", ErrorType.Problem);
        public static Error EmptyCurrency = new Error("Price.CurrencyEmpty", "La valuta non può essere vuota", ErrorType.Problem);

        public static Error EndDateBeforeStartDate = new Error("DateRange.EndDateBeforeStartDate", "La data di fine non può essere precedente alla data di inizio", ErrorType.Problem);

        public static Error InvalidLatitude = new Error("Coordinates.LatitudeInvalid", "La latitudine deve essere compresa tra -90 e 90", ErrorType.Problem);
        public static Error InvalidLongitude = new Error("Coordinates.LongitudeInvalid", "La longitudine deve essere compresa tra -180 e 180", ErrorType.Problem);
    }
}