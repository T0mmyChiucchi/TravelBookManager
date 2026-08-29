using TravelBookManager.Domain.Errors;
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

        private Trip(string name)
        {
            Name = name;
            Locations = new();
            OptimizedRoute = string.Empty;
            TotalDistance = 0.0;
            Raise(new TripPlannedEvent(Id, Name));
        }

        public static Result<Trip> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<Trip>.ValidationFailure(TripErrors.EmptyName);
            return Result.Success(new Trip(name));
        }

        public Result AddLocation(Location location)
        {
            if (location is null)
                return Result.Failure(TripErrors.NullLocation);
            if (Locations.Contains(location))
                return Result.Failure(TripErrors.LocationAlreadyAdded);
            Locations.Add(location);
            return Result.Success();
        }
    }
}