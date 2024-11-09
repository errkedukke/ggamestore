using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using MediatR;

namespace Gamestore.Application.Features.Genres.Commands.UpdateGenre;

public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Unit>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public UpdateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var genreToUpdate = _mapper.Map<Genre>(request);
        await _genreRepository.UpdateAsync(genreToUpdate);

        return Unit.Value;
    }
}
