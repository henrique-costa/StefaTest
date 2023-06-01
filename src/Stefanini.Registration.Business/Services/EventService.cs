using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Stefanini.Registration.Business.interfaces;
using Stefanini.Registration.Business.Validators;
using Stefanini.Registration.Data.Repositories;
using Stefanini.Registration.Domain.Dtos;
using Stefanini.Registration.Domain.Entities;
using Stefanini.Registration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Registration.Business.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<CreateEventDto> CreateEventAsync(CreateEventDto eventdto)
        {
            var validation = await new EventValidator().ValidateAsync(eventdto);
            if (!validation.IsValid) throw new ArgumentException(validation.Errors.First().ErrorMessage);


            var newEvent = _mapper.Map<Event>(eventdto);
            _eventRepository.Add(newEvent);
            await _eventRepository.CommitChanges();

            return _mapper.Map<CreateEventDto>(newEvent);
        }

        public async void DeleteEventAsync(int id)
        {
            var existingEvent = await _eventRepository.GetByIdAsync(id);
            if (existingEvent == null)
            {
                // Registration with the specified id was not found
                throw new NullReferenceException();
            }
            _eventRepository.Delete(existingEvent);
            await _eventRepository.CommitChanges();
        }

        public async Task<IEnumerable<EventDto>> GetAllEventAsync()
        {
            var entities = await _eventRepository.GetAsync();

            if (entities != null && entities.Any())
            {
                return _mapper.Map<IEnumerable<EventDto>>(entities); 
            }

            return Enumerable.Empty<EventDto>();
        }

        public async Task<Event> GetById(int id)
        {
            Event eventToGet = await _eventRepository.GetByIdAsync(id);
            return eventToGet;
        }

        public async Task<UpdateEventDto> UpdateEvent(UpdateEventDto dto)
        {

            var validation = await new UpdateEventValidator().ValidateAsync(dto);
            if (!validation.IsValid) throw new ArgumentException(validation.Errors.First().ErrorMessage);

            var existingEvent = await _eventRepository.GetByIdAsync(dto.Id);
            if (existingEvent == null)
            {
                // event with the specified id was not found
                return null;
            }

            // Update the properties of the existing event entity
            existingEvent.Name = dto.Name;
            existingEvent.Description = dto.Description;
            existingEvent.EventLocationId = dto.EventLocationId;
            existingEvent.UpdatedOn = dto.UpdatedOn;
            existingEvent.AvailableSeats = dto.AvailableSeats;
            existingEvent.Active = dto.Active;

            _eventRepository.Update(existingEvent);
            await _eventRepository.CommitChanges();

            // Return the updated event DTO
            return dto;
        }
    }
}
