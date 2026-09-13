using TravelBookManager.SharedKernel;

namespace TravelBookManager.Domain.Shared.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<Result<T>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<T>>> GetAllAsync();
        Task<Result> AddAsync(T entity);
        Task<Result> RemoveAsync(Guid id);
        Task<Result> UpdateAsync(T entity);
    }
}