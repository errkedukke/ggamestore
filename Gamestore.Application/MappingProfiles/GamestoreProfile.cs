using AutoMapper;
using Gamestore.Application.Features.Categories.Queries;
using Gamestore.Application.Features.Game.Queries;
using Gamestore.Domain;

namespace Gamestore.Application.MappingProfiles;

public class GamestoreProfile : Profile
{
    public GamestoreProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Game, GameDto>().ReverseMap();
    }
}
