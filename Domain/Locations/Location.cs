using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Locations.Errors;
using TravelBookManager.Domain.Shared.ValueObjects;

namespace TravelBookManager.Domain.Locations
{
    public enum LocationType { Monument, Museum, Restaurant, Park, Other }

    public sealed class Location : Entity
    {
        public string Name { get; set; }
        public LocationType Type { get; set; }

        //Value Object
        public Coordinates GeoCoordinates { get; set; }

        private Location(string name, LocationType type, Coordinates coordinates)
        {
            Name = name;
            Type = type;
            GeoCoordinates = coordinates;
        }

        public static Result<Location> Create(string name, LocationType type, double lati, double longi)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<Location>.ValidationFailure(LocationErrors.EmptyName);
            var coordinatesResult = Coordinates.Create(lati, longi);
            if (coordinatesResult.IsFailure)
                return Result<Location>.ValidationFailure(coordinatesResult.Error);
            return Result.Success(new Location(name, type, coordinatesResult.Value));
        }
    }
}