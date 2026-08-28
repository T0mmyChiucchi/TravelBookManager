namespace TravelBookManager.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}