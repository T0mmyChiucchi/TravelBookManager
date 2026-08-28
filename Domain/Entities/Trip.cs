using TravelBookManager.Domain.Events;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Entities
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
            Raise(new TripPlannedEvent(Id, Name));
        }

        public void AddLocation(Location location)
        {
            Locations.Add(location);
        }
    }
}