using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Users.Dto;

namespace TravelBookManager.Application.Users.Queries.GetUserByEmail
{
    public sealed record GetUserByEmailQuery(string Email) : IQuery<UserDto>;
}