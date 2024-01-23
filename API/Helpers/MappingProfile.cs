

using API.Dto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GameConsole, GameConsoleDto>()
            .ForMember(gc => gc.TechnicalSpecification, o => o.MapFrom(x => x.TechnicalSpecification))
            .ForMember(gc => gc.Brand, o => o.MapFrom(x => x.Brand))
            .ForMember(gc => gc.Company, o => o.MapFrom(x => x.Company));
        }
    }
}