using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Exceptions;
using MediatR;

namespace Gamestore.Application.Features.Genres.Commands.DeleteGenre;

public class DeleteGenreCommandHandler(IGenreRepository genreRepository) : IRequestHandler<DeleteGenreCommand, Unit>
{
    public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genreToDelete = await genreRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"The genre with the ID: {request.Id} was not found.");

        await genreRepository.DeleteAsync(genreToDelete, cancellationToken);

        return Unit.Value;
    }
}
