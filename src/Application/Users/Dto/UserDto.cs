namespace TravelBookManager.Application.Users.Dto
{
    public sealed record UserDto(Guid Id, string Name, string Email, string Username);
}