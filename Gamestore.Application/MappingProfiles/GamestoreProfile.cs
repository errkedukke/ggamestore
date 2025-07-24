using AutoMapper;
using Gamestore.Application.Features.Categories.Commands.CreateCategory;
using Gamestore.Application.Features.Categories.Commands.UpdateCategory;
using Gamestore.Application.Features.Categories.Queries;
using Gamestore.Application.Features.Game.Queries;
using Gamestore.Application.Features.Games.Commands.CreateGame;
using Gamestore.Application.Features.Games.Commands.UpdateGame;
using Gamestore.Application.Features.Genres.Commands.CreateGenre;
using Gamestore.Application.Features.Genres.Commands.UpdateGenre;
using Gamestore.Application.Features.Genres.Queries;
using Gamestore.Domain;

namespace Gamestore.Application.MappingProfiles;

public class GamestoreProfile : Profile
{
    public GamestoreProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

        CreateMap<Game, GameDto>().ReverseMap();
        CreateMap<Game, CreateGameCommand>().ReverseMap();
        CreateMap<Game, UpdateGameCommand>().ReverseMap();

        CreateMap<Genre, GenreDto>().ReverseMap();
        CreateMap<Genre, CreateGenreCommand>().ReverseMap();
        CreateMap<Genre, UpdateGenreCommand>().ReverseMap();
    }
}
