using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Stefanini.Registration.Data.Repositories.Abstractions
{
    public abstract class RepositoryBase<TEntity> : UnitOfWork, IRepositoryBase<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> dbSet;

        public RepositoryBase(StefaniniRegistrationContext dataContext) : base(dataContext)
        {
            dbSet = dataContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            return query;
        }

        public async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            var tResult = await Task.Run(
                () =>
                {
                    IQueryable<TEntity> query = dbSet;

                    if (filter != null)
                    {
                        query = query.Where(filter);
                    }

                    if (typeof(TEntity).GetProperty("Location") != null)
                    {
                        query = query.Include("Location");
                    }

                    return query;
                }
            );

            return tResult;
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity not provided!");

            dbSet.Add(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity not provided!");

            dbSet.Update(entity);

            return entity;
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity not provided!");
            dbSet.Remove(entity);
        }
    }
}
