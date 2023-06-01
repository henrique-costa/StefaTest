using Stefanini.Registration.Data.Repositories.Abstractions;
using Stefanini.Registration.Domain.Entities;
using Stefanini.Registration.Domain.Interfaces;

namespace Stefanini.Registration.Data.Repositories
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(StefaniniRegistrationContext dataContext) : base(dataContext)
        {
        }
    }
}
