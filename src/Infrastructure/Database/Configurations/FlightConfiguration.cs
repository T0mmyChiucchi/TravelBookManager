using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelBookManager.Domain.Flights;

namespace TravelBookManager.Infrastructure.Database.Configurations
{
    public sealed class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.Id);
            builder.OwnsOne(f => f.DepartureAirport, departureBuilder =>
            {
                departureBuilder.Property(d => d.AirportName).HasColumnName("DepartureAirport").IsRequired();
            });
            builder.OwnsOne(f => f.ArrivalAirport, arrivalBuilder =>
            {
                arrivalBuilder.Property(a => a.AirportName).HasColumnName("ArrivalAirport").IsRequired();
            });
            builder.OwnsOne(f => f.FlightDateRange, dateRangeBuilder =>
            {
                dateRangeBuilder.Property(dr => dr.StartDate).HasColumnName("StartDate").IsRequired();
                dateRangeBuilder.Property(dr => dr.EndDate).HasColumnName("EndDate").IsRequired();
            });
            builder.OwnsOne(f => f.Airline, airlineBuilder =>
            {
                airlineBuilder.Property(al => al.AirLineName).HasColumnName("AirlineName").IsRequired();
            });
            builder.OwnsOne(f => f.FlightPrice, priceBuilder =>
            {
                priceBuilder.Property(p => p.Currency).HasColumnName("PriceCurrency").IsRequired();
                priceBuilder.Property(p => p.Value).HasColumnName("PriceValue").IsRequired();
            });
        }
    }
}