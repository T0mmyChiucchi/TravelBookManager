using Travel_Book_Manager.SharedKernel;

namespace Travel_Book_Manager.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public List<Trip> SavedTrips { get; set; }
        // Value Objects
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string name, string email, string username, string password)
        {
            Name = name;
            Email = email;
            SavedTrips = new();

            Username = username;
            Password = password;
        }

        public void AddItinerary(Trip trip)
        {
            SavedTrips.Add(trip);
        }

    }
}