using AutoMapper;
using Gamestore.Application.Contracts.Logging;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Features.Common;
using Gamestore.Domain;
using MediatR;

namespace Gamestore.Application.Features.Genres.Commands.CreateGenre;

public class CreateGenreCommandHandler : CommandBase<CreateGenreCommand, Guid>, IRequestHandler<CreateGenreCommand, Guid>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public CreateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper, IAppLogger<CreateGenreCommand> appLogger)
        : base(appLogger)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateGenreCommandValidator();

        var genreToCreate = _mapper.Map<Genre>(request);
        await _genreRepository.CreateAsync(genreToCreate);

        return genreToCreate.Id;
    }
}
