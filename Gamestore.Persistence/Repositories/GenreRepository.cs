using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using Gamestore.Persistence.DatabaseContext;

namespace Gamestore.Persistence.Repositories;

public class GenreRepository(GamestoreDbContext dbContext) : GenericRepository<Genre>(dbContext), IGenreRepository;