using Travel_Book_Manager.SharedKernel;

namespace Travel_Book_Manager.Domain.Entities
{
    public class Flight : Entity
    {
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public string Airline { get; set; }

        public Flight(string departure, string arrival, DateTime start, DateTime end, decimal price, string airLine)
        {
            DepartureAirport = departure;
            ArrivalAirport = arrival;
            StartDate = start;
            EndDate = end;
            Price = price;
            Airline = airLine;
        }
    }
}