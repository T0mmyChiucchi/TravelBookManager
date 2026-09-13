using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelBookManager.Domain.Trips;

namespace TravelBookManager.Infrastructure.Database.Configurations
{
    public sealed class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(t => t.Id);
            builder.OwnsOne(t => t.Name, nameBuilder =>
            {
                nameBuilder.Property(n => n.Text).HasColumnName("Name").IsRequired();
            });
            builder.OwnsOne(t => t.TripRouteInfo, tripRouteInfoBuilder =>
            {
                tripRouteInfoBuilder.Property(r => r.OptimizedRoute).HasColumnName("OptimizedRoute").IsRequired();
                tripRouteInfoBuilder.Property(r => r.TotalDistance).HasColumnName("TotalDistance").IsRequired();
            });
            builder.HasMany(t => t.Locations).WithMany().UsingEntity(j => j.ToTable("TripLocations"));
            builder.Navigation(t => t.Locations).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}