using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Trips.Errors
{
    public record TripErrors : Error
    {
        public TripErrors(string code, string description, ErrorType type) : base(code, description, type) { }

        public static Error EmptyName = new Error("Trip.NameEmpty", "Il nome del viaggio non può essere vuoto", ErrorType.Problem);
        public static Error NullLocation = new Error("Trip.NullLocation", "Impossibile salvare un luogo vuoto", ErrorType.Problem);
        public static Error LocationAlreadyAdded = new Error("Trip.LocationAlreadyAdded", "Hai già aggiunto questo luogo", ErrorType.Conflict);
        public static Error NegativeDistance = new Error("Trip.DistanceNegative", "La distanza non può essere negativa", ErrorType.Problem);
    }
}