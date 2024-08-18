using AutoMapper;
using Gamestore.Application.Features.Game.Queries.GetAllGames;

namespace Gamestore.Application.MappingProfiles;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<GameDto, Game>().ReverseMap();
    }
}
