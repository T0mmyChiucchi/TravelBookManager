using System.Text.RegularExpressions;
using TravelBookManager.Domain.Users.Errors;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Users.ValueObjects
{
    public sealed record Email
    {
        public string Text { get; }

        private Email(string email) => Text = email;

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result<Email>.ValidationFailure(UserErrors.EmptyEmail);
            var cleanEmail = email.Trim().ToLowerInvariant();
            if (cleanEmail.Length > 254)
                return Result<Email>.ValidationFailure(UserErrors.EmailTooLong);
            if (!Regex.IsMatch(cleanEmail, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                return Result<Email>.ValidationFailure(UserErrors.InvalidEmailFormat);
            return Result.Success(new Email(cleanEmail));
        }
    }
}