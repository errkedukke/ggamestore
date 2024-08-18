using AutoMapper;
using Gamestore.Application.Features.Game.Queries.GetGame;
using Gamestore.Application.Features.Game.Queries.GetGames;

namespace Gamestore.Application.MappingProfiles;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<GameDto, Game>().ReverseMap();
        CreateMap<GameDetailsDto, Game>().ReverseMap();
    }
}
