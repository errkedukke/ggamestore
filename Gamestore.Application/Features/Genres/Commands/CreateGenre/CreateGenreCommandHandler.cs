using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using MediatR;

namespace Gamestore.Application.Features.Genres.Commands.CreateGenre;

public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Guid>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public CreateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var genreToCreate = _mapper.Map<Genre>(request);
        await _genreRepository.CreateAsync(genreToCreate, cancellationToken);

        return genreToCreate.Id;
    }
}
