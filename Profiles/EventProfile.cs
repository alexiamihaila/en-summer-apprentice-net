using AutoMapper;
using System.Threading.Tasks;
using TMSApi.Models;
using TMSApi.Models.Dto;

namespace TMSApi.Profiles { 
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventPatchDto, Eventss>().ReverseMap();
            CreateMap<Eventss, EventssDto>()
                 .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                 .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.EventName))
                 .ForMember(dest => dest.EventDescription, opt => opt.MapFrom(src => src.EventDescription))
                 .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType != null ? src.EventType.EventTypeName : string.Empty))
                 .ForMember(dest => dest.Venue, opt => opt.MapFrom(src => src.Venue != null ? src.Venue.LocationName : string.Empty)).ReverseMap();
        }
    }
}
