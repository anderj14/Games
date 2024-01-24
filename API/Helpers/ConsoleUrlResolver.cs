
using API.Dto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class ConsoleUrlResolver : IValueResolver<GameConsole, GameConsoleDto, string>
    {
        private readonly IConfiguration _config;

        public ConsoleUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(GameConsole source, GameConsoleDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiConsoleUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}