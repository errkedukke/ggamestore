using AutoMapper;
using Gamestore.Application.Features.Categories.Queries;
using Gamestore.Application.Features.Comments.Queries;
using Gamestore.Application.Features.Game.Queries;
using Gamestore.Application.Features.Genres.Queries;
using Gamestore.Domain;

namespace Gamestore.Application.MappingProfiles;

public class GamestoreProfile : Profile
{
    public GamestoreProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<Game, GameDto>().ReverseMap();
        CreateMap<Genre, GenreDto>().ReverseMap();
    }
}
