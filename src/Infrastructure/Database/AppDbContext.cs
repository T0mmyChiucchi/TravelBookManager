using Microsoft.EntityFrameworkCore;
using TravelBookManager.Domain.Destinations;
using TravelBookManager.Domain.Flights;
using TravelBookManager.Domain.Locations;
using TravelBookManager.Domain.Trips;
using TravelBookManager.Domain.Users;

namespace TravelBookManager.Infrastructure.Database
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Flight> Flights { get; set; } = null!;
        public DbSet<Destination> Destinations { get; set; } = null!;
        public DbSet<Trip> Trips { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}