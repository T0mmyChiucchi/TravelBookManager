using TravelBookManager.Domain.Users.ValueObjects;
using TravelBookManager.Domain.Users.Errors;
using Xunit;

namespace DomainTests.ValueObjects
{
    public class EmailTests
    {
        [Fact]
        public void When_EmailIsValid_ReturnsSuccess()
        {
            var result = Email.Create("test@example.com");
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void When_EmailIsInvalid_ReturnsInvalidFormatError()
        {
            var result = Email.Create("not-an-email");
            Assert.False(result.IsSuccess);
            Assert.Equal(UserErrors.InvalidEmailFormat, result.Error);
        }
    }
}
