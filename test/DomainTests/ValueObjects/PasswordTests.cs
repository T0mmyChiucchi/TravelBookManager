using TravelBookManager.Domain.Users.ValueObjects;
using TravelBookManager.Domain.Users.Errors;
using Xunit;

namespace DomainTests.ValueObjects
{
    public class PasswordTests
    {
        [Fact]
        public void When_PasswordIsValid_ReturnsSuccess()
        {
            var result = Password.Create("Pass123!");
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void When_PasswordTooShort_ReturnsError()
        {
            var result = Password.Create("P1!");
            Assert.False(result.IsSuccess);
            Assert.Equal(UserErrors.PasswordTooShort, result.Error);
        }
    }
}
