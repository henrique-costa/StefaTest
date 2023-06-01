using Microsoft.AspNetCore.Mvc;
using Stefanini.Registration.Business.interfaces;
using Stefanini.Registration.Domain.Dtos;

namespace Stefanini.Registration.Application.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDto>>> GetAllLocationsAsync()
        {
            var response = await _locationService.GetAllLocationsAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<LocationDto>> AddLocationAsync([FromBody] LocationDto location)
        {
            var response = await _locationService.AddLocationAsync(location);
            return Ok(response);
        }
    }
}
