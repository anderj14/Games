

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
            .ForMember(gc => gc.Brand, o => o.MapFrom(x => x.Brand.BrandName))
            .ForMember(gc => gc.Company, o => o.MapFrom(x => x.Company))
            .ForMember(gc => gc.PictureUrl, o => o.MapFrom<ConsoleUrlResolver>());

            CreateMap<Game, GameDto>()
            .ForMember(g => g.GameConsole, o => o.MapFrom(x => x.GameConsole.ConsoleName))
            .ForMember(g => g.GamePictureUrl, o => o.MapFrom<GameUrlResolver>());
        }
    }
}