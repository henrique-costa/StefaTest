using AutoMapper;
using FluentValidation;
using Stefanini.Registration.Business.interfaces;
using Stefanini.Registration.Business.Validators;
using Stefanini.Registration.Data.Repositories;
using Stefanini.Registration.Domain.Dtos;
using Stefanini.Registration.Domain.Entities;
using Stefanini.Registration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;


namespace Stefanini.Registration.Business.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IMapper _mapper;

        public RegistrationService(IRegistrationRepository registrationRepository, IMapper mapper)
        {
            _registrationRepository = registrationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegistrationDto>> GetAllRegistrationAsync()
        {
            var entities = await _registrationRepository.GetAsync();

            if (entities != null && entities.Any())
            {
                return _mapper.Map<IEnumerable<RegistrationDto>>(entities); ;
            }

            return Enumerable.Empty<RegistrationDto>();
        }

        
        public async Task<CreateRegistrationDto> CreateRegistrationAsync(CreateRegistrationDto registrationDto)
        {
            var validation = await new RegistrationValidator().ValidateAsync(registrationDto);
            if (!validation.IsValid) throw new ArgumentException(validation.Errors.First().ErrorMessage);

            var newRegistration = _mapper.Map<Domain.Entities.Registration>(registrationDto);
                       
            _registrationRepository.Add(newRegistration);
            await _registrationRepository.CommitChanges();

            return _mapper.Map<CreateRegistrationDto>(newRegistration);
        }

        public async Task<Domain.Entities.Registration> GetById(int id)
        {
            Domain.Entities.Registration registration = await _registrationRepository.GetByIdAsync(id);
            return registration;
        }

        public async Task<UpdateRegistrationDto> UpdateRegistration(UpdateRegistrationDto updateRegistrationDto)
        {
            var existingRegistration = await _registrationRepository.GetByIdAsync(updateRegistrationDto.RegistrationId);
            if (existingRegistration == null)
            {
                // Registration with the specified id was not found
                return null;
            }

            // Update the properties of the existing registration entity
            existingRegistration.FirstName = updateRegistrationDto.FirstName;
            existingRegistration.LastName = updateRegistrationDto.LastName;
            existingRegistration.Email = updateRegistrationDto.Email;
            existingRegistration.EventId = updateRegistrationDto.EventId;
            existingRegistration.Status = updateRegistrationDto.Status;
            existingRegistration.UpdatedOn = updateRegistrationDto.UpdatedOn;

            _registrationRepository.Update(existingRegistration);
            await _registrationRepository.CommitChanges();

            // Return the updated registration DTO
            return updateRegistrationDto;
        }

        public async void DeleteRegistrationAsync(int id)
        {
            var existingRegistration = await _registrationRepository.GetByIdAsync(id);
            if (existingRegistration == null)
            {
                // Registration with the specified id was not found
                throw new NullReferenceException();
            }
            _registrationRepository.Delete(existingRegistration);
            await _registrationRepository.CommitChanges();
        }
    }
}
