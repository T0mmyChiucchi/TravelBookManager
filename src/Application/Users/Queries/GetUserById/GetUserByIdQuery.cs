using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Users.Dto;

namespace TravelBookManager.Application.Users.Queries.GetUserById
{
    public sealed record GetUserByIdQuery(Guid Id) : IQuery<UserDto>;
}