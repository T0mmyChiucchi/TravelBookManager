using TravelBookManager.Domain.Destinations.Errors;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Destinations.ValueObjects
{
    public sealed record Country
    {
        public string Name { get; }

        private Country(string countryName) => Name = countryName;

        public static Result<Country> Create(string countryName)
        {
            if (string.IsNullOrWhiteSpace(countryName))
                return Result<Country>.ValidationFailure(DestinationErrors.EmptyCountry);
            var cleanCountryName = countryName.Trim();
            if (cleanCountryName.Length < 2 || cleanCountryName.Length > 100)
                return Result<Country>.ValidationFailure(DestinationErrors.InvalidCountryLength);
            return Result.Success(new Country(cleanCountryName));
        }
    
        #pragma warning disable CS8618
        private Country() { }
#pragma warning restore CS8618
    }
}