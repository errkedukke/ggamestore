namespace Gamestore.Application.MappingProfiles;

using AutoMapper;
using Gamestore.Application.Features.Game.Queries;
using Gamestore.Domain;

public class GamestoreProfile : Profile
{
    public GamestoreProfile()
    {
        CreateMap<GameDto, Game>().ReverseMap();
    }
}
