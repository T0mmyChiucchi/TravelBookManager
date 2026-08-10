namespace Travel_Book_Manager.Domain.Entities;

public enum LocationType { Monument, Museum, Restaurant, Park, Other }

public class Location
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public LocationType Type { get; set; }
    //Value Objects
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Location(string name, LocationType type, double lati, double longi)
    {
        Id = Guid.NewGuid();
        Name = name;
        Type = type;
        Latitude = lati;
        Longitude = longi;
    }
}