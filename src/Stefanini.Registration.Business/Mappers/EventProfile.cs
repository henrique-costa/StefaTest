using AutoMapper;
using Stefanini.Registration.Domain.Dtos;
using Stefanini.Registration.Domain.Entities;


namespace Stefanini.Registration.Business.Mappers
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap().ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));
            CreateMap<Event, CreateEventDto>().ReverseMap();
            CreateMap<Event, UpdateEventDto>().ReverseMap();
           
        }
    }
}
