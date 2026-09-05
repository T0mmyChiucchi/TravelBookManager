using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Users.Dto;

namespace TravelBookManager.Application.Users.Queries.GetUserByUsername
{
    public sealed record GetUserByUsernameQuery(string Username) : IQuery<UserDto>;
}