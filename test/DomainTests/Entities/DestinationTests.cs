using TravelBookManager.Domain.Destinations;
using TravelBookManager.Domain.Destinations.ValueObjects;
using TravelBookManager.Domain.Shared.ValueObjects;

namespace DomainTests.Entities
{
    public class DestinationTests
    {
        [Fact]
        public void When_CreateDestinationWithValidData_ReturnsSuccess()
        {
            var name = Name.Create("Roma").Value;
            var country = Country.Create("Italy").Value;
            var coords = Coordinates.Create(41.9028, 12.4964).Value;
            var score = PopularityScore.Create(95).Value;

            var dest = Destination.Create(name, country, coords, score);

            Assert.Equal("Roma", dest.Name.Text);
            Assert.Equal("Italy", dest.CountryName.Name);
            Assert.Equal(95, dest.PopularityScore.Value);
        }

        [Fact]
        public void When_ChangeCoordinates_UpdatesCoordinates()
        {
            var name = Name.Create("Roma").Value;
            var country = Country.Create("Italy").Value;
            var coords = Coordinates.Create(41.9028, 12.4964).Value;
            var score = PopularityScore.Create(95).Value;
            var dest = Destination.Create(name, country, coords, score);

            var newCoords = Coordinates.Create(45.4642, 9.1900).Value;
            dest.ChangeCoordinates(newCoords);
            Assert.Equal(45.4642, dest.GeoCoordinates.Latitude);
        }
    }
}
