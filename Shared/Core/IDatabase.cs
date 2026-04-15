using System.Linq.Expressions;

namespace Backend_Game.Shared.Core.Ports
{
    public interface IDatabase
    {
        Task AddAsync<T>(string collectionName, T entity);
        Task<T?> FindAsync<T>(string collectionName, Expression<Func<T, bool>> predicate);
        Task<List<T>> GetListAsync<T>(string collectionName, Expression<Func<T, bool>>? predicate = null);
        Task UpdateAsync<T>(string collectionName, Guid id, T entity);
        Task DeleteAsync<T>(string collectionName, Guid id);
    }
}