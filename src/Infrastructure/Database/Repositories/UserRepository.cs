using Microsoft.EntityFrameworkCore;
using TravelBookManager.Domain.Users;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Infrastructure.Database.Repositories
{
    public sealed class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<Result<User>> GetByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Text == email);
            if (user is null)
                return Result.Failure<User>(new Error("Database.NotFound", "Utente non trovato con questa email.", ErrorType.NotFound));
            return Result.Success(user);
        }

        public async Task<Result<User>> GetByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username.Text == username);
            if (user is null)
                return Result.Failure<User>(new Error("Database.NotFound", "Utente non trovato con questo username.", ErrorType.NotFound));
            return Result.Success(user);
        }
    }
}