using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Domain.Shared.Errors;
using TravelBookManager.SharedKernel;
using Xunit;

namespace TravelBookManager.Domain.UnitTest.ValueObjects
{
    public class CoordinatesTests
    {
        [Fact]
        public void When_LatitudeIsLessThanMinus90_ReturnsInvalidLatitudeError()
        {
            var result = Coordinates.Create(-91, 0);

            Assert.False(result.IsSuccess);
            Assert.Equal(ValueObjectsErrors.InvalidLatitude, result.Error);
        }

        [Fact]
        public void When_LatitudeIsGreaterThan90_ReturnsInvalidLatitudeError()
        {
            var result = Coordinates.Create(91, 0);

            Assert.False(result.IsSuccess);
            Assert.Equal(ValueObjectsErrors.InvalidLatitude, result.Error);
        }

        [Fact]
        public void When_LongitudeIsLessThanMinus180_ReturnsInvalidLongitudeError()
        {
            var result = Coordinates.Create(0, -181);

            Assert.False(result.IsSuccess);
            Assert.Equal(ValueObjectsErrors.InvalidLongitude, result.Error);
        }

        [Fact]
        public void When_LongitudeIsGreaterThan180_ReturnsInvalidLongitudeError()
        {
            var result = Coordinates.Create(0, 181);

            Assert.False(result.IsSuccess);
            Assert.Equal(ValueObjectsErrors.InvalidLongitude, result.Error);
        }

        [Fact]
        public void When_CoordinatesAreValid_ReturnsSuccess()
        {
            var result = Coordinates.Create(45.5, 9.2);

            Assert.True(result.IsSuccess);
            Assert.Equal(45.5, result.Value.Latitude);
            Assert.Equal(9.2, result.Value.Longitude);
        }
    }
}
