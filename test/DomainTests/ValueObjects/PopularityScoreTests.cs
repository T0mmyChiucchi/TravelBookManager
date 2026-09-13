using TravelBookManager.Domain.Destinations.ValueObjects;
using TravelBookManager.Domain.Destinations.Errors;
using Xunit;

namespace DomainTests.ValueObjects
{
    public class PopularityScoreTests
    {
        [Fact]
        public void When_ScoreIsValid_ReturnsSuccess()
        {
            var result = PopularityScore.Create(85);
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void When_ScoreInvalid_ReturnsError()
        {
            var result = PopularityScore.Create(105);
            Assert.False(result.IsSuccess);
            Assert.Equal(DestinationErrors.InvalidPopularityScore, result.Error);
        }
    }
}
