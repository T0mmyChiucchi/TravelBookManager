using TravelBookManager.Domain.Errors;
using TravelBookManager.Domain.Events;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public List<Trip> SavedTrips { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

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