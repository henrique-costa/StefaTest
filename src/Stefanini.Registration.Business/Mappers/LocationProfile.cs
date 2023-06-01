using AutoMapper;
using Stefanini.Registration.Domain.Dtos;
using Stefanini.Registration.Domain.Entities;

namespace Stefanini.Registration.Business.Mappers
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationDto>().ReverseMap();
        }
    }
}
