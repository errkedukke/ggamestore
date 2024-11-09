﻿using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.Genres.Commands.DeleteGenre;

public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, Unit>
{
    private readonly IGenreRepository _genreRepository;

    public DeleteGenreCommandHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genreToDelete = await _genreRepository.GetByIdAsync(request.Id);
        await _genreRepository.DeleteAsync(genreToDelete);

        return Unit.Value;
    }
}
