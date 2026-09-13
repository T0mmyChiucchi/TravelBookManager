using TravelBookManager.Domain.Flights.ValueObjects;
using TravelBookManager.Domain.Flights.Errors;
using Xunit;

namespace DomainTests.ValueObjects
{
    public class AirlineTests
    {
        [Fact]
        public void When_AirlineIsValid_ReturnsSuccess()
        {
            var result = Airline.Create("Alitalia");
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void When_AirlineEmpty_ReturnsError()
        {
            var result = Airline.Create("");
            Assert.False(result.IsSuccess);
            Assert.Equal(FlightErrors.EmptyAirline, result.Error);
        }
    }
}
