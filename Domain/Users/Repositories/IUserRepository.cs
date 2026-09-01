using TravelBookManager.Domain.Shared.Repositories;

namespace TravelBookManager.Domain.Users.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
    }
}