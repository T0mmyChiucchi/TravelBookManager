using TravelBookManager.Domain.Destinations;
using TravelBookManager.Domain.Destinations.Repositories;

namespace TravelBookManager.Infrastructure.Database.Repositories
{
    public sealed class DestinationRepository : RepositoryBase<Destination>, IDestinationRepository
    {
        public DestinationRepository(AppDbContext context) : base(context) { }
    }
}