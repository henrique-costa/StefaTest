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
    public interface IEventRepository : IUnitOfWork
    {
        Task<IQueryable<Event>> GetAsync(Expression<Func<Entities.Event, bool>>? filter = null);
        Event Add(Event eventToAdd);
        //Task<ReadRegistrationDto> GetByIdAsync(int registrationId);
        Task<Event> GetByIdAsync(int id);

        Event Update(Event registration);
        void Delete(Event registration);
    }
}
