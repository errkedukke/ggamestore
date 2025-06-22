using Gamestore.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Identity.DbContext;

public class GamestoreIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public GamestoreIdentityDbContext(DbContextOptions<GamestoreIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(GamestoreIdentityDbContext).Assembly);
    }
}
