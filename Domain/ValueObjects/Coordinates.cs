namespace TravelBookManager.Domain.ValueObjects
{
    public sealed record Coordinates
    {
        public double Longitude { get; }
        public double Latitude { get; }

        private Coordinates(double lati, double longi)
        {
            Latitude = lati;
            Longitude = longi;
        }

        public static Coordinates Create(double lati, double longi)
        {
            return new Coordinates(lati, longi);
        }
    }
}