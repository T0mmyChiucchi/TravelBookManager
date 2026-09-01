using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Flights.Events
{
    public sealed record FlightSearchedEvent : IDomainEvent
    {
        public Guid UserId { get; }
        public string DepartureAirport { get; }
        public string ArrivalAirport { get; }
        public DateTime OccuredOnUtc { get; } = DateTime.UtcNow;

        public FlightSearchedEvent(Guid userId, string departure, string arrival)
        {
            UserId = userId;
            DepartureAirport = departure;
            ArrivalAirport = arrival;
        }
    }
}