using Microsoft.EntityFrameworkCore;
using TravelBookManager.Domain.Trips;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Infrastructure.Database;
using TravelBookManager.Infrastructure.Database.Repositories;
using Xunit;
using System.Threading.Tasks;
using System;

namespace InfrastructureTests.Repositories
{
    public class TripRepositoryTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public async Task When_AddTrip_CanBeRetrieved()
        {
            var context = GetDbContext();
            var repo = new TripRepository(context);
            
            var trip = Trip.Create(Name.Create("My Trip").Value);
            await repo.AddAsync(trip);
            
            var retrieved = await repo.GetByIdAsync(trip.Id);
            Assert.True(retrieved.IsSuccess);
            Assert.Equal("My Trip", retrieved.Value.Name.Text);
        }

        [Fact]
        public async Task When_UpdateTrip_SavesChanges()
        {
            var context = GetDbContext();
            var repo = new TripRepository(context);
            
            var trip = Trip.Create(Name.Create("My Trip").Value);
            await repo.AddAsync(trip);
            
            trip.Rename(Name.Create("New Trip Name").Value);
            await repo.UpdateAsync(trip);
            
            var retrieved = await repo.GetByIdAsync(trip.Id);
            Assert.True(retrieved.IsSuccess);
            Assert.Equal("New Trip Name", retrieved.Value.Name.Text);
        }
    }
}
