using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Shared.ValueObjects;

namespace TravelBookManager.Domain.Locations
{
    public enum LocationType { Monument, Museum, Restaurant, Park, Other }

    public sealed class Location : Entity
    {
        public Name Name { get; private set; }
        public LocationType Type { get; private set; }
        public Coordinates GeoCoordinates { get; private set; }

        private Location(Name name, LocationType type, Coordinates coordinates)
        {
            Name = name;
            Type = type;
            GeoCoordinates = coordinates;
        }

        #pragma warning disable CS8618
        private Location() { }
#pragma warning restore CS8618

        public static Location Create(Name name, LocationType type, Coordinates geoCoordinates)
        {
            return new Location(name, type, geoCoordinates);
        }

        public void ChangeName(Name newName) => Name = newName;

        public void ChangeType(LocationType newType) => Type = newType;

        public void ChangeCoordinates(Coordinates newCoordinates) => GeoCoordinates = newCoordinates;
    }
}