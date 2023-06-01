using Microsoft.AspNetCore.Mvc;
using Stefanini.Registration.Business.interfaces;
using Stefanini.Registration.Business.Services;
using Stefanini.Registration.Domain.Dtos;

namespace Stefanini.Registration.Application.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationDto>>> GetAllRegistrationAsync()
        {
            var response = await _registrationService.GetAllRegistrationAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<RegistrationDto>> AddRegistrationAsync([FromBody] CreateRegistrationDto registration)
        {
            var response = await _registrationService.CreateRegistrationAsync(registration);
            
            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ReadRegistrationDto>> GetByIdRegistrationAsync(int id)
        {
            var response = await _registrationService.GetById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<ActionResult<UpdateRegistrationDto>> UpdateRegistration([FromBody] UpdateRegistrationDto registrationToUpdate)
        {
            var response =  await _registrationService.UpdateRegistration(registrationToUpdate);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<ActionResult<UpdateRegistrationDto>> DeleteRegistration(int id)
        {
            _registrationService.DeleteRegistrationAsync(id);
            return Ok();
        }
    }
}
