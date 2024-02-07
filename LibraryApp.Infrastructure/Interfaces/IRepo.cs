using System.Linq.Expressions;

namespace LibraryApp.Infrastructure.Interfaces
{
    public interface IRepo<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity entity);
    }
}