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

        public static DateRange Create(DateTime start, DateTime end)
        {
            return new DateRange(start, end);
        }
    }
}