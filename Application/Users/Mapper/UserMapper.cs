using TravelBookManager.Application.Users.Dto;
using TravelBookManager.Domain.Users;

namespace TravelBookManager.Application.Users.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToDto(User user)
        {
            return new UserDto(user.Id, user.Name.Text, user.Email.Text, user.Username.Text);
        }
    }
}