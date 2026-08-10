using Travel_Book_Manager.SharedKernel;

namespace Travel_Book_Manager.Domain.Entities
{
    public class Trip : Entity
    {
        public string Name { get; set; }
        public List<Location> Locations { get; set; }
        public string OptimizedRoute { get; set; }
        public double TotalDistance { get; set; }

        public Trip(string name)
        {
            Name = name;
            Locations = new();
            OptimizedRoute = string.Empty;
            TotalDistance = 0.0;
        }

        public void AddLocation(Location location)
        {
            Locations.Add(location);
        }
    }
}