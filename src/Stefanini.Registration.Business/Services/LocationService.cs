using AutoMapper;
using Stefanini.Registration.Business.interfaces;
using Stefanini.Registration.Business.Validators;
using Stefanini.Registration.Data;
using Stefanini.Registration.Domain.Dtos;
using Stefanini.Registration.Domain.Entities;
using Stefanini.Registration.Domain.Interfaces;
using System.Linq.Expressions;

namespace Stefanini.Registration.Business.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocationDto>> GetAllLocationsAsync()
        {
            var entities = await _locationRepository.GetAsync();

            if (entities != null && entities.Any())
            {
                return _mapper.Map<IEnumerable<LocationDto>>(entities); ;
            }

            return Enumerable.Empty<LocationDto>();
        }

        public async Task<LocationDto> AddLocationAsync(LocationDto location)
        {
            var validation = await new LocationValidator().ValidateAsync(location);
            if (!validation.IsValid) throw new ArgumentException(validation.Errors.First().ErrorMessage);

            var newLocation = _mapper.Map<Location>(location);
            _locationRepository.Add(newLocation);
            await _locationRepository.CommitChanges();

            return _mapper.Map<LocationDto>(newLocation);
        }

        
    }
}
