using TravelBookManager.Domain.Trips;
using TravelBookManager.Domain.Trips.ValueObjects;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Domain.Shared.Errors;
using Xunit;

namespace DomainTests.Entities
{
    public class TripTests
    {
        [Fact]
        public void When_CreateTripWithValidData_ReturnsSuccess()
        {
            var name = Name.Create("Vacanze Romane").Value;
            var trip = Trip.Create(name);
            Assert.Equal("Vacanze Romane", trip.Name.Text);
        }

        [Fact]
        public void When_RenameTripWithValidName_UpdatesName()
        {
            var name = Name.Create("Old Name").Value;
            var trip = Trip.Create(name);
            var newName = Name.Create("New Name").Value;
            var result = trip.Rename(newName);
            Assert.True(result.IsSuccess);
            Assert.Equal("New Name", trip.Name.Text);
        }
    }
}
