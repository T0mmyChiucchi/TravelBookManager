using TravelBookManager.Domain.Destinations.Errors;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Destinations.ValueObjects
{
    public sealed record PopularityScore
    {
        public double Value { get; }

        private PopularityScore(double value) => Value = value;

        public static Result<PopularityScore> Create(double value)
        {
            if (value < 0)
                return Result<PopularityScore>.ValidationFailure(DestinationErrors.NegativePopularity);
            if (value > 10)
                return Result<PopularityScore>.ValidationFailure(DestinationErrors.TooPopular);
            return Result.Success(new PopularityScore(value));
        }
    
        #pragma warning disable CS8618
        private PopularityScore() { }
#pragma warning restore CS8618
    }
}