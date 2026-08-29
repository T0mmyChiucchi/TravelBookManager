using TravelBookManager.Domain.Errors;
using TravelBookManager.SharedKernel;

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

        public static Result<Coordinates> Create(double lati, double longi)
        {
            if (lati < -90 || lati > 90)
                return Result<Coordinates>.ValidationFailure(ValueObjectsErrors.InvalidLatitude);
            if (longi < -180 || longi > 180)
                return Result<Coordinates>.ValidationFailure(ValueObjectsErrors.InvalidLongitude);
            return Result.Success(new Coordinates(lati, longi));
        }
    }
}