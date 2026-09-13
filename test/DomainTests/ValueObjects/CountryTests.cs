using TravelBookManager.Domain.Destinations.ValueObjects;
using TravelBookManager.Domain.Destinations.Errors;
using Xunit;

namespace DomainTests.ValueObjects
{
    public class CountryTests
    {
        [Fact]
        public void When_CountryIsValid_ReturnsSuccess()
        {
            var result = Country.Create("Italy");
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void When_CountryEmpty_ReturnsError()
        {
            var result = Country.Create("");
            Assert.False(result.IsSuccess);
            Assert.Equal(DestinationErrors.EmptyCountry, result.Error);
        }
    }
}
