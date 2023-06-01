using System.Linq.Expressions;

namespace Stefanini.Registration.Data.Repositories.Abstractions
{
    public interface IRepositoryBase<TEntity>
    {
        Task<TEntity?> GetByIdAsync(int id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
