using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Destinations.Errors;
using TravelBookManager.Domain.Shared.ValueObjects;

namespace TravelBookManager.Domain.Destinations
{
    public sealed class Destination : Entity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public double PopularityScore { get; set; }

        //Value object
        public Coordinates GeoCoordinates { get; set; }

        private Destination(string name, string country, Coordinates coordinates, double score)
        {
            Name = name;
            Country = country;
            GeoCoordinates = coordinates;
            PopularityScore = score;
        }

        public static Result<Destination> Create(string name, string country, double lati, double longi, double score)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<Destination>.ValidationFailure(DestinationErrors.EmptyName);
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