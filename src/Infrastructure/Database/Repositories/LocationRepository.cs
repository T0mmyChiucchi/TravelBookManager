using TravelBookManager.Domain.Locations;
using TravelBookManager.Domain.Locations.Repositories;

namespace TravelBookManager.Infrastructure.Database.Repositories
{
    public sealed class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(AppDbContext context) : base(context) { }
    }
}