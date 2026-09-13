using TravelBookManager.Domain.Flights.ValueObjects;
using TravelBookManager.Domain.Flights.Errors;
using Xunit;

namespace DomainTests.ValueObjects
{
    public class AirportTests
    {
        [Fact]
        public void When_AirportIsValid_ReturnsSuccess()
        {
            var result = Airport.Create("Fiumicino");
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void When_AirportEmpty_ReturnsError()
        {
            var result = Airport.Create("");
            Assert.False(result.IsSuccess);
            Assert.Equal(FlightErrors.EmptyAirport, result.Error);
        }
    }
}
