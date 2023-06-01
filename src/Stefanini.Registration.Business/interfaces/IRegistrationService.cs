using Stefanini.Registration.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Registration.Business.interfaces
{
    public interface IRegistrationService
    {
        Task<IEnumerable<RegistrationDto>> GetAllRegistrationAsync();
        Task<CreateRegistrationDto> CreateRegistrationAsync(CreateRegistrationDto registration);
        Task<Domain.Entities.Registration> GetById(int id);
        Task<UpdateRegistrationDto> UpdateRegistration(UpdateRegistrationDto dto);
        void DeleteRegistrationAsync(int id);
    }
}
