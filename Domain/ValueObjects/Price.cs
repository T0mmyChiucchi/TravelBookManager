using TravelBookManager.Domain.Errors;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.ValueObjects
{
    public sealed record Price
    {
        public string Currency { get; }
        public decimal Value { get; }

        private Price(string currency, decimal value)
        {
            Currency = currency;
            Value = value;
        }

        public static Result<Price> Create(string currency, decimal value)
        {
            if (string.IsNullOrWhiteSpace(currency))
                return Result<Price>.ValidationFailure(ValueObjectsErrors.EmptyCurrency);
            if (value < 0)
                return Result<Price>.ValidationFailure(ValueObjectsErrors.NegativeValue);
            return Result.Success(new Price(currency, value));
        }
    }
}