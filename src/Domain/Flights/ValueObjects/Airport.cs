using TravelBookManager.Domain.Flights.Errors;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Flights.ValueObjects
{
    public sealed record Airport
    {
        public string AirportName { get; }

        private Airport(string airportName) => AirportName = airportName;

        public static Result<Airport> Create(string airportName)
        {
            if (string.IsNullOrWhiteSpace(airportName))
                return Result<Airport>.ValidationFailure(FlightErrors.EmptyAirport);
            airportName = airportName.Trim();
            if (airportName.Length < 3 || airportName.Length > 150)
                return Result<Airport>.ValidationFailure(FlightErrors.InvalidAirportLength);
            return Result.Success(new Airport(airportName));
        }
    
        #pragma warning disable CS8618
        private Airport() { }
#pragma warning restore CS8618
    }
}