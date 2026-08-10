using Travel_Book_Manager.SharedKernel;

namespace Travel_Book_Manager.Domain.Entities
{
    public class Destination : Entity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double PopularityScore { get; set; }

        public Destination(string name, string country, double lati, double longi, double score)
        {
            Name = name;
            Country = country;
            Latitude = lati;
            Longitude = longi;
            PopularityScore = score;
        }
    }
}