namespace TravelBookManager.Application.Destinations.Dto
{
    public sealed record DestinationDto(Guid Id, string Name, string Country, double Latitude, double Longitude, double PopularityScore);
}
