using TravelBookManager.Domain.Users;
using TravelBookManager.Domain.Users.Errors;
using TravelBookManager.Domain.Users.ValueObjects;
using TravelBookManager.Domain.Shared.ValueObjects;
using Xunit;

namespace DomainTests.Entities
{
    public class UserTests
    {
        [Fact]
        public void When_ChangeEmailWithValidEmail_EmailIsUpdated()
        {
            var name = Name.Create("Mario Rossi").Value;
            var email = Email.Create("mario@rossi.com").Value;
            var username = Username.Create("mariorossi").Value;
            var password = Password.Create("Password123!").Value;

            var user = User.Create(name, email, username, password);
            var newEmail = Email.Create("nuova@email.com").Value;

            var result = user.ChangeEmail(newEmail);

            Assert.True(result.IsSuccess);
            Assert.Equal(newEmail, user.Email);
        }

        [Fact]
        public void When_AddNullItinerary_ReturnsNullTripError()
        {
            var name = Name.Create("Mario Rossi").Value;
            var email = Email.Create("mario@rossi.com").Value;
            var username = Username.Create("mariorossi").Value;
            var password = Password.Create("Password123!").Value;

            var user = User.Create(name, email, username, password);

            var result = user.AddItinerary(null!);

            Assert.False(result.IsSuccess);
            Assert.Equal(UserErrors.NullTrip, result.Error);
        }
    }
}
