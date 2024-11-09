using MediatR;

namespace Gamestore.Application.Features.Genres.Queries.GetGenre;

public record GetGenreQuery(Guid id) : IRequest<GenreDto>;
