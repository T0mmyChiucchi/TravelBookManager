using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Users.Errors
{
    public record UserErrors : Error
    {
        public UserErrors(string code, string description, ErrorType type) : base(code, description, type) { }

        public static Error EmptyEmail = new Error("Email.EmailEmpty", "L'email non può essere vuota", ErrorType.Validation);
        public static Error EmailTooLong = new Error("Email.EmailTooLong", "L'email non può essere più lunga di 254", ErrorType.Validation);
        public static Error InvalidEmailFormat = new Error("Email.InvalidEmailFormat", "Il formato dell'email non è valido", ErrorType.Validation);

        public static Error EmptyUsername = new Error("Username.UsernameEmpty", "Lo username non può essere vuoto", ErrorType.Validation);
        public static Error UsernameTooShort = new Error("Username.UsernameTooShort", "Lo username non può essere più corto di 3 caratteri", ErrorType.Validation);
        public static Error UsernameTooLong = new Error("Username.UsernameTooLong", "Lo username non può essere più lungo di 30 caratteri", ErrorType.Validation);
        public static Error InvalidUsernameFormat = new Error("Username.UsernameInvalidFormat", "Lo username può contenere solo lettere, numeri, underscore e punti", ErrorType.Validation);

        public static Error EmptyPassword = new Error("Password.PasswordEmpty", "La password non può essere vuota", ErrorType.Validation);
        public static Error PasswordTooShort = new Error("Password.PasswordTooShort", "La password deve avere almeno 8 caratteri", ErrorType.Validation);
        public static Error PasswordTooLong = new Error("Password.PasswordTooLong", "La password non può essere più lunga di 128 caratteri", ErrorType.Validation);
        public static Error PasswordRequiresUppercase = new Error("Password.PasswordRequiresUppercase", "Inserire almeno una maiuscola", ErrorType.Validation);
        public static Error PasswordRequiresLowercase = new Error("Password.PasswordRequiresLowercase", "Inserire almeno una minuscola", ErrorType.Validation);
        public static Error PasswordRequiresDigit = new Error("Password.PasswordRequiresDigit", "Inserire almeno un numero", ErrorType.Validation);
        public static Error PasswordRequiresSpecial = new Error("Password.PasswordRequiresSpecial", "Inserire almeno un carattere speciale", ErrorType.Validation);

        public static Error NullTrip = new Error("User.NullTrip", "Impossibile salvare un viaggio vuoto", ErrorType.Validation);
        public static Error TripAlreadySaved = new Error("User.TripAlreadySaved", "Hai già salvato questo viaggio", ErrorType.Conflict);
        public static Error TripNotFound = new Error("User.TripNotFound", "Il viaggio non è stato trovato", ErrorType.NotFound);
    }
}