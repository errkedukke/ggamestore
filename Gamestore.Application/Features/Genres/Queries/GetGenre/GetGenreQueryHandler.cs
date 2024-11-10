using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.Genres.Queries.GetGenre;

public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, GenreDto>
{
    private IGenreRepository _genreRepository;
    private IMapper _mapper;

    public GetGenreQueryHandler(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task<GenreDto> Handle(GetGenreQuery request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetByIdAsync(request.Id);
        var result = _mapper.Map<GenreDto>(genre);

        return result;
    }
}

