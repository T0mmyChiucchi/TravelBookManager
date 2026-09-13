using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelBookManager.Domain.Destinations;

namespace TravelBookManager.Infrastructure.Database.Configurations
{
    public sealed class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.HasKey(d => d.Id);
            builder.OwnsOne(d => d.Name, nameBuilder =>
            {
                nameBuilder.Property(n => n.Text).HasColumnName("Name").IsRequired();
            });
            builder.OwnsOne(d => d.CountryName, countryBuilder =>
            {
                countryBuilder.Property(c => c.Name).HasColumnName("Country").IsRequired();
            });
            builder.OwnsOne(d => d.GeoCoordinates, geoCoordinatesBuilder =>
            {
                geoCoordinatesBuilder.Property(g => g.Latitude).HasColumnName("Latitude").IsRequired();
                geoCoordinatesBuilder.Property(g => g.Longitude).HasColumnName("Longitude").IsRequired();
            });
            builder.OwnsOne(d => d.PopularityScore, popularityBuilder =>
            {
                popularityBuilder.Property(p => p.Value).HasColumnName("PopularityScore").IsRequired();
            });
        }
    }
}