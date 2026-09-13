using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Destinations.Errors
{
    public record DestinationErrors : Error
    {
        public DestinationErrors(string code, string description, ErrorType type) : base(code, description, type) { }

        public static Error EmptyCountry = new Error("Country.CountryEmpty", "Il nome della nazione non può essere vuoto", ErrorType.Validation);
        public static Error InvalidCountryLength = new Error("Country.CountryInvalidLength", "La lunghezza del nome del paese non è valida", ErrorType.Validation);

        public static Error NegativePopularity = new Error("PopularityScore.PopularityNegative", "La popolarità non può essere negativa", ErrorType.Validation);
        public static Error TooPopular = new Error("PopularityScore.TooPopular", "La popolarità non può superare il massimo", ErrorType.Validation);
    }
}