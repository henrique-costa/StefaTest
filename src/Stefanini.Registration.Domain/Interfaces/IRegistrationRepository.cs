using Stefanini.Registration.Domain.Dtos;
using Stefanini.Registration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Registration.Domain.Interfaces
{
    public interface IRegistrationRepository : IUnitOfWork
    {
        Task<IQueryable<Entities.Registration>> GetAsync(Expression<Func<Entities.Registration, bool>>? filter = null);
        Entities.Registration Add(Entities.Registration registration);
       //Task<ReadRegistrationDto> GetByIdAsync(int registrationId);
        Task<Entities.Registration> GetByIdAsync(int id);

        Entities.Registration Update(Entities.Registration registration);
        void Delete(Entities.Registration registration);

    }
}
