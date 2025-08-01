﻿using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using Gamestore.Persistence.DatabaseContext;

namespace Gamestore.Persistence.Repositories;

public class GameRepository(GamestoreDbContext dbContext)
    : GenericRepository<Game>(dbContext), IGameRepository;
