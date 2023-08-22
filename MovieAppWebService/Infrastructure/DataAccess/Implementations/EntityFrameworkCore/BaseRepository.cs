using Infrastructure.DataAccess.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.Implementations.EntityFrameworkCore
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var ctx = new TContext())
            {
                var entityEntry = await ctx.Set<TEntity>().AddAsync(entity);
                await ctx.SaveChangesAsync();
                return entityEntry.Entity;
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? takeCount = null, params string[] includeList)
        {
            using (var ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                if (includeList != null && includeList.Length > 0)
                {
                    foreach (var include in includeList)
                    {
                        dbSet = dbSet.Include(include);
                    }
                }
                if (predicate != null)
                {
                    dbSet = dbSet.Where(predicate);
                }
                if (orderBy != null)
                {
                    dbSet = orderBy(dbSet);
                }
                if (takeCount.HasValue)
                {
                    return await dbSet.Take(takeCount.Value).ToListAsync();
                }
                return await dbSet.ToListAsync();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList)
        {
            using (var ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                if (includeList != null && includeList.Length > 0)
                {
                    foreach (var include in includeList)
                    {
                        dbSet = dbSet.Include(include);
                    }
                }
                return await dbSet.SingleOrDefaultAsync(predicate);
            }
        }

        public async Task RemoveAsync(TEntity entity)
        {
            using (var ctx = new TContext())
            {
                ctx.Set<TEntity>().Remove(entity);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (var ctx = new TContext())
            {
                ctx.Set<TEntity>().Update(entity);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
