using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Shared.Errors;
using TravelBookManager.Domain.Flights.Errors;

namespace TravelBookManager.Domain.Flights.ValueObjects
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
                return Result<Price>.ValidationFailure(FlightErrors.EmptyCurrency);
            var cleanCurrency = currency.Trim();
            if (value < 0)
                return Result<Price>.ValidationFailure(FlightErrors.NegativeValue);
            return Result.Success(new Price(cleanCurrency, value));
        }
    }
}