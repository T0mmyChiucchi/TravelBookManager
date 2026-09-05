using System.Text.RegularExpressions;
using TravelBookManager.Domain.Users.Errors;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Users.ValueObjects
{
    public sealed record Username
    {
        public string Text { get; }

        private Username(string username) => Text = username;

        public static Result<Username> Create(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return Result<Username>.ValidationFailure(UserErrors.EmptyUsername);
            var cleanUsername = username.Trim().ToLowerInvariant();
            if (cleanUsername.Length < 3)
                return Result<Username>.ValidationFailure(UserErrors.UsernameTooShort);
            if (cleanUsername.Length > 30)
                return Result<Username>.ValidationFailure(UserErrors.UsernameTooLong);
            if (!Regex.IsMatch(cleanUsername, @"^[a-zA-Z0-9_.]+$"))
                return Result<Username>.ValidationFailure(UserErrors.InvalidUsernameFormat);
            return Result.Success(new Username(cleanUsername));
        }
    }
}