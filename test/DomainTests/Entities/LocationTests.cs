using TravelBookManager.Domain.Locations;
using TravelBookManager.Domain.Shared.ValueObjects;
using Xunit;

namespace DomainTests.Entities
{
    public class LocationTests
    {
        [Fact]
        public void When_CreateLocationWithValidData_ReturnsSuccess()
        {
            var name = Name.Create("Colosseo").Value;
            var coords = Coordinates.Create(41.8902, 12.4922).Value;
            
            var location = Location.Create(name, coords, "Monumento");
            
            Assert.Equal("Colosseo", location.Name.Text);
        }
    }
}
