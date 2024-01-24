
using API.Dto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class GameUrlResolver : IValueResolver<Game, GameDto, string>
    {
        private readonly IConfiguration _config;

        public GameUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Game source, GameDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.GamePictureUrl))
            {
                return _config["ApiGameUrl"] + source.GamePictureUrl;
            }

            return null;
        }
    }
}