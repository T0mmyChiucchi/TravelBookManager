namespace TravelBookManager.Application.Flights.Dto
{
    public sealed record FlightDto(Guid Id, string Departure, string Arrival, string Airline, DateTime Start, DateTime End, string Currency, decimal Price);
}
