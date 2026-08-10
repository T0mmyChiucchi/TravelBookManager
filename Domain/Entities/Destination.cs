namespace Travel_Book_Manager.Domain.Entities;

public class Destination
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double PopularityScore { get; set; }

    public Destination(string name, string country, double lati, double longi, double score)
    {
        Id = Guid.NewGuid();
        Name = name;
        Country = country;
        Latitude = lati;
        Longitude = longi;
        PopularityScore = score;
    }
}