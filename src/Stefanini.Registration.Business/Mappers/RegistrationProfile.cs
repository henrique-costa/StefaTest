using AutoMapper;
using Stefanini.Registration.Domain.Dtos;

namespace Stefanini.Registration.Business.Mappers
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile()
        {
            CreateMap<Domain.Entities.Registration, RegistrationDto>().ReverseMap();
            CreateMap<CreateRegistrationDto ,Domain.Entities.Registration>().ReverseMap();
            CreateMap<ReadRegistrationDto ,Domain.Entities.Registration>().ReverseMap();

            
        }
    }
}
