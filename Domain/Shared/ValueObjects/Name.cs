using TravelBookManager.Domain.Shared.Errors;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Shared.ValueObjects
{
    public sealed record Name
    {
        public string Text { get; }

        private Name(string name) { Text = name; }

        public static Result<Name> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<Name>.ValidationFailure(ValueObjectsErrors.EmptyName);
            var cleanName = name.Trim();
            if (cleanName.Length > 100)
                return Result<Name>.ValidationFailure(ValueObjectsErrors.NameTooLong);
            return Result.Success(new Name(cleanName));
        }
    }
}