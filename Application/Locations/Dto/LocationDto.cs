namespace TravelBookManager.Application.Locations.Dto
{
    public sealed record LocationDto(Guid Id, string Name, string Type, double Latitude, double Longitude);
}