using Microsoft.EntityFrameworkCore;
using TravelBookManager.Domain.Destinations;
using TravelBookManager.Domain.Destinations.ValueObjects;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Infrastructure.Database;
using TravelBookManager.Infrastructure.Database.Repositories;

namespace InfrastructureTests.Repositories
{
    public class DestinationRepositoryTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public async Task When_AddDestination_CanBeRetrieved()
        {
            var context = GetDbContext();
            var repo = new DestinationRepository(context);

            var name = Name.Create("Roma").Value;
            var country = Country.Create("Italy").Value;
            var coords = Coordinates.Create(41.9, 12.4).Value;
            var score = PopularityScore.Create(9).Value;

            var dest = Destination.Create(name, country, coords, score);
            await repo.AddAsync(dest);

            var retrieved = await repo.GetByIdAsync(dest.Id);
            Assert.True(retrieved.IsSuccess);
            Assert.Equal("Roma", retrieved.Value.Name.Text);
        }
    }
}
