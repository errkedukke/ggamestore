using MediatR;

namespace Gamestore.Application.Features.Genres.Queries.GetGenres;

public record GetGenresQuery : IRequest<List<GenreDto>>;
