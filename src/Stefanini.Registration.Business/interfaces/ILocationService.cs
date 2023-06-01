using Stefanini.Registration.Domain.Dtos;

namespace Stefanini.Registration.Business.interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDto>> GetAllLocationsAsync();
        Task<LocationDto> AddLocationAsync(LocationDto location);
    }
}