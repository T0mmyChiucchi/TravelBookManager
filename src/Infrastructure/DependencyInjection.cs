using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TravelBookManager.Domain.Destinations.Repositories;
using TravelBookManager.Domain.Flights.Repositories;
using TravelBookManager.Domain.Locations.Repositories;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.Infrastructure.Database;
using TravelBookManager.Infrastructure.Database.Repositories;

namespace TravelBookManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IDestinationRepository, DestinationRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            return services;
        }
    }
}