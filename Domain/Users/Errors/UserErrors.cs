using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Users.Errors
{
    public record UserErrors : Error
    {
        public UserErrors(string code, string description, ErrorType type) : base(code, description, type) { }

        public static Error EmptyName = new Error("User.NameEmpty", "Il nome non può essere vuoto", ErrorType.Problem);
        public static Error EmptyEmail = new Error("User.EmailEmpty", "L'email non può essere vuota", ErrorType.Problem);
        public static Error EmptyUsername = new Error("User.UsernameEmpty", "Lo username non può essere vuoto", ErrorType.Problem);

        public static Error EmptyPassword = new Error("User.PasswordEmpty", "La password non può essere vuota", ErrorType.Problem);
        public static Error PasswordTooShort = new Error("User.PasswordTooShort", "La password deve avere almeno 8 caratteri", ErrorType.Problem);

        public static Error NullTrip = new Error("User.NullTrip", "Impossibile salvare un viaggio vuoto", ErrorType.Problem);
        public static Error TripAlreadySaved = new Error("User.TripAlreadySaved", "Hai già salvato questo viaggio", ErrorType.Conflict);
    }
}