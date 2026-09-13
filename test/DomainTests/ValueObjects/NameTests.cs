using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Domain.Shared.Errors;
using Xunit;

namespace DomainTests.ValueObjects
{
    public class NameTests
    {
        [Fact]
        public void When_NameIsValid_ReturnsSuccess()
        {
            var result = Name.Create("Valid Name");
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void When_NameEmpty_ReturnsError()
        {
            var result = Name.Create(" ");
            Assert.False(result.IsSuccess);
            Assert.Equal(ValueObjectsErrors.EmptyName, result.Error);
        }
    }
}
