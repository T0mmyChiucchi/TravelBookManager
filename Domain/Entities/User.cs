namespace Travel_Book_Manager.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Trip> SavedTrips { get; set; }
    // Value Objects
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public User(string name, string email, string username, string password)
    {
        Id = Guid.NewGuid();
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