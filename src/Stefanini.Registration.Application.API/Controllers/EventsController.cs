using Microsoft.AspNetCore.Mvc;
using Stefanini.Registration.Business.interfaces;
using Stefanini.Registration.Business.Services;
using Stefanini.Registration.Domain.Dtos;

namespace Stefanini.Registration.Application.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAllEventAsync()
        {
            var response = await _eventService.GetAllEventAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateEventDto>> AddRegistrationAsync([FromBody] CreateEventDto eventDto)
        {
            var response = await _eventService.CreateEventAsync(eventDto);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateEventDto>> UpdateRegistration([FromBody] UpdateEventDto eventToUpdate)
        {
            var response = await _eventService.UpdateEvent(eventToUpdate);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<ActionResult<UpdateEventDto>> DeleteEvent(int id)
        {
             _eventService.DeleteEventAsync(id);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReadEventDto>> GetByIdRegistrationAsync(int id)
        {
            var response = await _eventService.GetById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
    }
}
