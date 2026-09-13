using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Domain.Destinations.ValueObjects;

namespace TravelBookManager.Domain.Destinations
{
    public sealed class Destination : Entity
    {
        public Name Name { get; private set; }
        public Country CountryName { get; private set; }
        public Coordinates GeoCoordinates { get; private set; }
        public PopularityScore PopularityScore { get; private set; }

        private Destination(Name name, Country countryName, Coordinates geoCoordinates, PopularityScore score)
        {
            Name = name;
            CountryName = countryName;
            GeoCoordinates = geoCoordinates;
            PopularityScore = score;
        }

        #pragma warning disable CS8618
        private Destination() { }
#pragma warning restore CS8618

        public static Destination Create(Name name, Country countryName, Coordinates geoCoordinates, PopularityScore score)
        {
            return new Destination(name, countryName, geoCoordinates, score);
        }

        public void ChangeName(Name newName) => Name = newName;

        public void ChangeCountry(Country newCountry) => CountryName = newCountry;

        public void ChangeCoordinates(Coordinates newCoordinates) => GeoCoordinates = newCoordinates;

        public void ChangePopularity(PopularityScore newScore) => PopularityScore = newScore;
    }
}