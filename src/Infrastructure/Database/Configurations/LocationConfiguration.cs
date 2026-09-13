using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelBookManager.Domain.Locations;

namespace TravelBookManager.Infrastructure.Database.Configurations
{
    public sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);
            builder.OwnsOne(l => l.Name, nameBuilder =>
            {
                nameBuilder.Property(n => n.Text).HasColumnName("Name").IsRequired();
            });
            builder.Property(l => l.Type).HasConversion<string>().IsRequired();
            builder.OwnsOne(l => l.GeoCoordinates, geoCoordinatesBuilder =>
            {
                geoCoordinatesBuilder.Property(g => g.Latitude).HasColumnName("Latitude").IsRequired();
                geoCoordinatesBuilder.Property(g => g.Longitude).HasColumnName("Longitude").IsRequired();
            });
        }
    }
}