using TravelBookManager.Domain.Users.ValueObjects;
using TravelBookManager.Domain.Users.Errors;
using Xunit;

namespace DomainTests.ValueObjects
{
    public class UsernameTests
    {
        [Fact]
        public void When_UsernameIsValid_ReturnsSuccess()
        {
            var result = Username.Create("user_123");
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void When_UsernameEmpty_ReturnsError()
        {
            var result = Username.Create("");
            Assert.False(result.IsSuccess);
            Assert.Equal(UserErrors.EmptyUsername, result.Error);
        }
    }
}
