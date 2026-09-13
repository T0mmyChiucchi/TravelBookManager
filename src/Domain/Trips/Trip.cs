using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Locations;
using TravelBookManager.Domain.Trips.Errors;
using TravelBookManager.Domain.Trips.Events;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Domain.Trips.ValueObjects;

namespace TravelBookManager.Domain.Trips
{
    public sealed class Trip : Entity
    {
        public Name Name { get; private set; }
        private readonly List<Location> _locations = new();
        public IReadOnlyCollection<Location> Locations => _locations.AsReadOnly();
        public RouteInfo TripRouteInfo { get; private set; }

        private Trip(Name name)
        {
            Name = name;
            TripRouteInfo = RouteInfo.Empty();
            Raise(new TripPlannedEvent(Id, Name.Text));
        }

        #pragma warning disable CS8618
        private Trip() { }
#pragma warning restore CS8618

        public static Trip Create(Name name) => new Trip(name);

        public Result AddLocation(Location location)
        {
            if (location is null)
                return Result.Failure(TripErrors.NullLocation);
            if (_locations.Contains(location))
                return Result.Failure(TripErrors.LocationAlreadyAdded);
            _locations.Add(location);
            Raise(new LocationAddedToTripEvent(Id, location.Id));
            return Result.Success();
        }

        public Result RemoveLocation(Location location)
        {
            if (location is null)
                return Result.Failure(TripErrors.NullLocation);
            if (!_locations.Contains(location))
                return Result.Failure(TripErrors.LocationNotFound);
            _locations.Remove(location);
            Raise(new LocationRemovedFromTripEvent(Id, location.Id));
            return Result.Success();
        }

        public Result UpdateRoute(RouteInfo newRoute)
        {
            if (newRoute is null)
                return Result.Failure(TripErrors.NullRoute);
            TripRouteInfo = newRoute;
            Raise(new TripRouteUpdatedEvent(Id, newRoute.OptimizedRoute, newRoute.TotalDistance));
            return Result.Success();
        }

        public Result Rename(Name newName)
        {
            Name = newName;
            Raise(new TripRenamedEvent(Id, Name.Text));
            return Result.Success();
        }
    }
}