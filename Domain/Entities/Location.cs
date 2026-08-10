using Travel_Book_Manager.SharedKernel;

namespace Travel_Book_Manager.Domain.Entities
{
    public enum LocationType { Monument, Museum, Restaurant, Park, Other }

    public class Location : Entity
    {
        public string Name { get; set; }
        public LocationType Type { get; set; }
        //Value Objects
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location(string name, LocationType type, double lati, double longi)
        {
            Name = name;
            Type = type;
            Latitude = lati;
            Longitude = longi;
        }
    }
}