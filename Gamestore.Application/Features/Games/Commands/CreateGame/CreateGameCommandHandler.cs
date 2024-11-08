using AutoMapper;
using MediatR;

namespace Gamestore.Application.Features.Game.Commands.CreateGame
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;

        public CreateGameCommandHandler(IMapper mapper, IGameRepository gameRepository)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
        }

        public Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
