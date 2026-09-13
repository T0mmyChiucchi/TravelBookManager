using TravelBookManager.Domain.Flights;
using TravelBookManager.Domain.Flights.ValueObjects;

namespace DomainTests.Entities
{
    public class FlightTests
    {
        [Fact]
        public void When_CreateFlightWithValidData_ReturnsSuccess()
        {
            var airline = Airline.Create("Ryanair").Value;
            var origin = Airport.Create("Milano").Value;
            var destination = Airport.Create("Roma").Value;
            var dates = DateRange.Create(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(1).AddHours(2)).Value;
            var price = Price.Create("EUR", 49.99m).Value;

            var flight = Flight.Create(origin, destination, dates, airline, price).Value;

            Assert.Equal("Ryanair", flight.Airline.AirLineName);
            Assert.Equal(49.99m, flight.FlightPrice.Value);
        }
    }
}
