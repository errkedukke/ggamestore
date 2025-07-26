using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Exceptions;
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
        var genreToUpdate = await _genreRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"The genre with the ID: {request.Id} was not found.");

        _mapper.Map(request, genreToUpdate);
        await _genreRepository.UpdateAsync(genreToUpdate, cancellationToken);

        return Unit.Value;
    }
}
