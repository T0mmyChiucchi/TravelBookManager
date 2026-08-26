using TravelBookManager.Domain.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Entities
{
    public class Destination : Entity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public double PopularityScore { get; set; }

        //Value object
        public Coordinates GeoCoordinates { get; set; }

        public Destination(string name, string country, double lati, double longi, double score)
        {
            Name = name;
            Country = country;
            GeoCoordinates = Coordinates.Create(lati, longi);
            PopularityScore = score;
        }
    }
}