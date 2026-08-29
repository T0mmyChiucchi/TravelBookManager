using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Errors
{
    public record LocationErrors : Error
    {
        public LocationErrors(string code, string description, ErrorType type) : base(code, description, type) { }

        public static Error EmptyName = new Error("Location.NameEmpty", "Il nome del luogo non può essere vuoto", ErrorType.Problem);
    }
}