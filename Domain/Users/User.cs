using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Trips;
using TravelBookManager.Domain.Users.Errors;
using TravelBookManager.Domain.Users.Events;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Domain.Users.ValueObjects;

namespace TravelBookManager.Domain.Users
{
    public sealed class User : Entity
    {
        public Name Name { get; private set; }
        private readonly List<Trip> _savedTrips = new();
        public IReadOnlyCollection<Trip> SavedTrips => _savedTrips.AsReadOnly();
        public Email Email { get; private set; }
        public Username Username { get; private set; }
        public Password Password { get; private set; }

        private User(Name name, Email email, Username username, Password password)
        {
            Name = name;
            Email = email;
            Username = username;
            Password = password;
            Raise(new UserRegisteredEvent(Id, Email.Text));
        }

        public static Result<User> Create(Name name, Email email, Username username, Password password)
        {
            return Result.Success(new User(name, email, username, password));
        }


        public Result ChangeEmail(Email newEmail)
        {
            Email = newEmail;
            Raise(new UserEmailChangedEvent(Id, newEmail.Text));
            return Result.Success();
        }

        public Result UpdateBasicInfo(Name newName, Username newUsername)
        {
            Name = newName;
            Username = newUsername;
            Raise(new UserBasicInfoUpdatedEvent(Id, newName.Text, newUsername.Text));
            return Result.Success();
        }

        public Result ChangePassword(Password newPassword)
        {
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
            _savedTrips.Add(trip);
            return Result.Success();
        }

        public Result RemoveItinerary(Trip trip)
        {
            if (trip is null)
                return Result.Failure(UserErrors.NullTrip);
            if (!_savedTrips.Contains(trip))
                return Result.Failure(UserErrors.TripNotFound);
            _savedTrips.Remove(trip);
            return Result.Success();
        }
    }
}