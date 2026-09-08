using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Shared.ValueObjects;

namespace TravelBookManager.Domain.Locations
{
    public enum LocationType { Monument, Museum, Restaurant, Park, Other }

    public sealed class Location : Entity
    {
        public Name Name { get; set; }
        public LocationType Type { get; set; }
        public Coordinates GeoCoordinates { get; set; }

        private Location(Name name, LocationType type, Coordinates coordinates)
        {
            Name = name;
            Type = type;
            GeoCoordinates = coordinates;
        }

        public static Result<Location> Create(Name name, LocationType type, double lati, double longi)
        {
            var coordinatesResult = Coordinates.Create(lati, longi);
            if (coordinatesResult.IsFailure)
                return Result<Location>.ValidationFailure(coordinatesResult.Error);
            return Result.Success(new Location(name, type, coordinatesResult.Value));
        }
    }
}