using Stefanini.Registration.Domain.Entities;
using System.Linq.Expressions;

namespace Stefanini.Registration.Domain.Interfaces
{
    public interface ILocationRepository : IUnitOfWork
    {
        Task<IQueryable<Location>> GetAsync(Expression<Func<Location, bool>>? filter = null);
        Location Add(Location music);
    }
}
