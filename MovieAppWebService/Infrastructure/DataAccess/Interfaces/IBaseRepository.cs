using Infrastructure.Model;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? takeCount = null, params string[] includeList);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
