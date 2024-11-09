using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.Genres.Queries.GetGenres;

public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, List<GenreDto>>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public GetGenresQueryHandler(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task<List<GenreDto>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
    {
        var genres = await _genreRepository.GetAsync();
        var result = _mapper.Map<List<GenreDto>>(genres);

        return result;
    }
}