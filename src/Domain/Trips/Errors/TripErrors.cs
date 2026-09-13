using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Trips.Errors
{
    public record TripErrors : Error
    {
        public TripErrors(string code, string description, ErrorType type) : base(code, description, type) { }

        public static Error NullLocation = new Error("Trip.NullLocation", "Impossibile salvare un luogo vuoto", ErrorType.Validation);
        public static Error LocationAlreadyAdded = new Error("Trip.LocationAlreadyAdded", "Hai già aggiunto questo luogo", ErrorType.Conflict);
        public static Error NegativeDistance = new Error("RouteInfo.DistanceNegative", "La distanza non può essere negativa", ErrorType.Validation);
        public static Error LocationNotFound = new Error("Trip.LocationNotFound", "Impossibile trovare il luogo", ErrorType.NotFound);
        public static Error InvalidRoute = new Error("RouteInfo.RouteInvalid", "Il percorso non è valido", ErrorType.Validation);
        public static Error NullRoute = new Error("Trip.RouteNull", "Il percorso non può essere vuoto", ErrorType.Validation);
    }
}