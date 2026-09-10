using TravelBookManager.Domain.Flights.Errors;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Flights.ValueObjects
{
    public sealed record Airline
    {
        public string AirLineName { get; }

        private Airline(string airLine) => AirLineName = airLine;

        public static Result<Airline> Create(string airLine)
        {
            if (string.IsNullOrWhiteSpace(airLine))
                return Result<Airline>.ValidationFailure(FlightErrors.EmptyAirline);
            airLine = airLine.Trim();
            if (airLine.Length < 2 || airLine.Length > 100)
                return Result<Airline>.ValidationFailure(FlightErrors.InvalidAirlineLength);
            return Result.Success(new Airline(airLine));
        }
    }
}