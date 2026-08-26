using TravelBookManager.Domain.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Entities
{
    public enum LocationType { Monument, Museum, Restaurant, Park, Other }

    public class Location : Entity
    {
        public string Name { get; set; }
        public LocationType Type { get; set; }

        //Value Object
        public Coordinates GeoCoordinates { get; set; }

        public Location(string name, LocationType type, double lati, double longi)
        {
            Name = name;
            Type = type;
            GeoCoordinates = Coordinates.Create(lati, longi);
        }
    }
}