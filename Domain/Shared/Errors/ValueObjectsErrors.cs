using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Shared.Errors
{
    public record ValueObjectsErrors : Error
    {
        public ValueObjectsErrors(string code, string description, ErrorType type) : base(code, description, type) { }

        public static Error NegativeValue = new Error("Price.NegativeValue", "Il valore del prezzo non può essere negativo", ErrorType.Validation);
        public static Error EmptyCurrency = new Error("Price.CurrencyEmpty", "La valuta non può essere vuota", ErrorType.Validation);

        public static Error EndDateBeforeStartDate = new Error("DateRange.EndDateBeforeStartDate", "La data di fine non può essere precedente alla data di inizio", ErrorType.Validation);

        public static Error InvalidLatitude = new Error("Coordinates.LatitudeInvalid", "La latitudine deve essere compresa tra -90 e 90", ErrorType.Validation);
        public static Error InvalidLongitude = new Error("Coordinates.LongitudeInvalid", "La longitudine deve essere compresa tra -180 e 180", ErrorType.Validation);

        public static Error EmptyName = new Error("Name.NameEmpty", "Il nome non può essere vuoto", ErrorType.Validation);
        public static Error NameTooLong = new Error("Name.NameTooLong", "Il nome non può essere più lungo di 100 caratteri", ErrorType.Validation);
    }
}