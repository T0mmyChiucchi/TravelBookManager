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

        public static Price Create(string currency, decimal value)
        {
            return new Price(currency, value);
        }
    }
}