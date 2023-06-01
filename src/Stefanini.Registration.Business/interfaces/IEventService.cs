using Stefanini.Registration.Domain.Dtos;
using Stefanini.Registration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Registration.Business.interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllEventAsync();
        Task<CreateEventDto> CreateEventAsync(CreateEventDto registration);
        Task<Event> GetById(int id);
        Task<UpdateEventDto> UpdateEvent(UpdateEventDto dto);
        void DeleteEventAsync(int id);

    }
}
