using TravelBookManager.Domain.Shared.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Users.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<Result<User>> GetByEmailAsync(string email);
        Task<Result<User>> GetByUsernameAsync(string username);
    }
}