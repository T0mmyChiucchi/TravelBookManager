using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Destinations.Errors
{
    public record DestinationErrors : Error
    {
        public DestinationErrors(string code, string description, ErrorType type) : base(code, description, type) { }

        public static Error EmptyCountry = new Error("Destination.CountryEmpty", "Il nome della nazione non può essere vuoto", ErrorType.Validation);
        public static Error NegativePopularity = new Error("Destination.PopularityNegative", "La popolarità non può essere negativa", ErrorType.Validation);
    }
}