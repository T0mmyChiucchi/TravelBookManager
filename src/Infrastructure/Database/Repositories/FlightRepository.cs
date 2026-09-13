using TravelBookManager.Domain.Flights;
using TravelBookManager.Domain.Flights.Repositories;

namespace TravelBookManager.Infrastructure.Database.Repositories
{
    public sealed class FlightRepository : RepositoryBase<Flight>, IFlightRepository
    {
        public FlightRepository(AppDbContext context) : base(context) { }
    }
}