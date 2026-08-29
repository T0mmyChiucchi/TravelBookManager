using TravelBookManager.Domain.Errors;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.ValueObjects
{
    public sealed record DateRange
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        private DateRange(DateTime start, DateTime end)
        {
            StartDate = start;
            EndDate = end;
        }

        public static Result<DateRange> Create(DateTime start, DateTime end)
        {
            if (end < start)
                return Result<DateRange>.ValidationFailure(ValueObjectsErrors.EndDateBeforeStartDate);
            return Result.Success(new DateRange(start, end));
        }
    }
}