using Microsoft.EntityFrameworkCore;
using TravelBookManager.Domain.Shared.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Infrastructure.Database.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;

        protected RepositoryBase(AppDbContext context) => _context = context;

        public async Task<Result> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result<IEnumerable<T>>> GetAllAsync()
        {
            var entities = await _context.Set<T>().ToListAsync();
            return Result.Success<IEnumerable<T>>(entities);
        }

        public async Task<Result<T>> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity is null)
                return Result.Failure<T>(new Error("Database.NotFound", $"{typeof(T).Name} non trovato nel database.", ErrorType.NotFound));
            return Result.Success(entity);
        }

        public async Task<Result> RemoveAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity is null)
                return Result.Failure(new Error("Database.NotFound", $"{typeof(T).Name} non trovato nel database.", ErrorType.NotFound));
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}