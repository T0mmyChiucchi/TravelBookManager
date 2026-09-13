using TravelBookManager.Domain.Trips;
using TravelBookManager.Domain.Trips.Repositories;

namespace TravelBookManager.Infrastructure.Database.Repositories
{
    public sealed class TripRepository : RepositoryBase<Trip>, ITripRepository
    {
        public TripRepository(AppDbContext context) : base(context) { }
    }
}