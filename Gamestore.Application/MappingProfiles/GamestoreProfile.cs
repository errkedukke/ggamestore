using AutoMapper;
using Gamestore.Application.Features.Categories.Commands.CreateCategory;
using Gamestore.Application.Features.Categories.Queries;
using Gamestore.Domain;

namespace Gamestore.Application.MappingProfiles;

public class GamestoreProfile : Profile
{
    public GamestoreProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<CreateCategoryCommand, Category>().ReverseMap();
    }
}
