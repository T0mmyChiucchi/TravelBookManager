using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Trips;
using TravelBookManager.Domain.Users.Errors;
using TravelBookManager.Domain.Users.Events;

namespace TravelBookManager.Domain.Users
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public List<Trip> SavedTrips { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        private User(string name, string email, string username, string password)
        {
            Name = name;
            Email = email;
            SavedTrips = new();
            Username = username;
            Password = password;
            Raise(new UserRegisteredEvent(Id, Email));
        }

        public static Result<User> Create(string name, string email, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<User>.ValidationFailure(UserErrors.EmptyName);
            if (string.IsNullOrWhiteSpace(email))
                return Result<User>.ValidationFailure(UserErrors.EmptyEmail);
            if (string.IsNullOrWhiteSpace(username))
                return Result<User>.ValidationFailure(UserErrors.EmptyUsername);
            if (string.IsNullOrWhiteSpace(password))
                return Result<User>.ValidationFailure(UserErrors.EmptyPassword);
            if (password.Length < 8)
                return Result<User>.ValidationFailure(UserErrors.PasswordTooShort);
            return Result.Success(new User(name, email, username, password));

        }


        public Result ChangeEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
                return Result.Failure(UserErrors.EmptyEmail);
            Email = newEmail;
            Raise(new UserEmailChangedEvent(Id, newEmail));
            return Result.Success();
        }

        public Result UpdateBasicInfo(string newName, string newUsername)
        {
            if (string.IsNullOrWhiteSpace(newName))
                return Result.Failure(UserErrors.EmptyName);
            if (string.IsNullOrWhiteSpace(newUsername))
                return Result.Failure(UserErrors.EmptyUsername);
            Name = newName;
            Username = newUsername;
            Raise(new UserBasicInfoUpdatedEvent(Id, newName, newUsername));
            return Result.Success();
        }

        public Result ChangePassword(string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                return Result.Failure(UserErrors.EmptyPassword);
            if (newPassword.Length < 8)
                return Result.Failure(UserErrors.PasswordTooShort);
            Password = newPassword;
            Raise(new UserPasswordChangedEvent(Id));
            return Result.Success();
        }

        public Result AddItinerary(Trip trip)
        {
            if (trip is null)
                return Result.Failure(UserErrors.NullTrip);
            if (SavedTrips.Contains(trip))
                return Result.Failure(UserErrors.TripAlreadySaved);
            SavedTrips.Add(trip);
            return Result.Success();
        }

    }
}