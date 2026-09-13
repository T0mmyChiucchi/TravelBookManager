using TravelBookManager.Domain.Users.Errors;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Users.ValueObjects
{
    public sealed record Password
    {
        public string Hash { get; }

        private Password(string password) => Hash = password;

        public static Result<Password> Create(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return Result<Password>.ValidationFailure(UserErrors.EmptyPassword);
            if (password.Length < 8)
                return Result<Password>.ValidationFailure(UserErrors.PasswordTooShort);
            if (password.Length > 128)
                return Result<Password>.ValidationFailure(UserErrors.PasswordTooLong);
            if (!password.Any(char.IsUpper))
                return Result<Password>.ValidationFailure(UserErrors.PasswordRequiresUppercase);
            if (!password.Any(char.IsLower))
                return Result<Password>.ValidationFailure(UserErrors.PasswordRequiresLowercase);
            if (!password.Any(char.IsDigit))
                return Result<Password>.ValidationFailure(UserErrors.PasswordRequiresDigit);
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
                return Result<Password>.ValidationFailure(UserErrors.PasswordRequiresSpecial);
            return Result.Success(new Password(password));
        }
    
        #pragma warning disable CS8618
        private Password() { }
#pragma warning restore CS8618
    }
}