using AutoMapper;

namespace Gamestore.Application.MappingProfiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameDto, Game>().ReverseMap();
        }
    }
}
