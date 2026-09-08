using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Destinations.Errors;
using TravelBookManager.Domain.Shared.ValueObjects;

namespace TravelBookManager.Domain.Destinations
{
    public sealed class Destination : Entity
    {
        public Name Name { get; set; }
        public string Country { get; set; }
        public double PopularityScore { get; set; }

        //Value object
        public Coordinates GeoCoordinates { get; set; }

        private Destination(Name name, string country, Coordinates coordinates, double score)
        {
            Name = name;
            Country = country;
            GeoCoordinates = coordinates;
            PopularityScore = score;
        }

        public static Result<Destination> Create(Name name, string country, double lati, double longi, double score)
        {
            if (string.IsNullOrWhiteSpace(country))
                return Result<Destination>.ValidationFailure(DestinationErrors.EmptyCountry);
            var coordinatesResult = Coordinates.Create(lati, longi);
            if (coordinatesResult.IsFailure)
                return Result<Destination>.ValidationFailure(coordinatesResult.Error);
            if (score < 0)
                return Result<Destination>.ValidationFailure(DestinationErrors.NegativePopularity);
            return Result.Success(new Destination(name, country, coordinatesResult.Value, score));
        }
    }
}