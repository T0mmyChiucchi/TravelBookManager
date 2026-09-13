using TravelBookManager.Domain.Flights;
using TravelBookManager.Domain.Flights.ValueObjects;
using Xunit;
using System;

namespace DomainTests.Entities
{
    public class FlightTests
    {
        [Fact]
        public void When_CreateFlightWithValidData_ReturnsSuccess()
        {
            var airline = Airline.Create("Ryanair").Value;
            var origin = Airport.Create("Milano", "BGY").Value;
            var destination = Airport.Create("Roma", "CIA").Value;
            var dates = DateRange.Create(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(1).AddHours(2)).Value;
            var price = Price.Create(49.99m, "EUR").Value;
            
            var flight = Flight.Create(airline, origin, destination, dates, price);
            
            Assert.Equal("Ryanair", flight.FlightAirline.Name);
            Assert.Equal(49.99m, flight.FlightPrice.Amount);
        }
    }
}
