using Gamestore.Domain;
using Gamestore.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Persistence.DatabaseContext
{
    public class GamestoreDbContext : DbContext
    {
        public GamestoreDbContext(DbContextOptions<GamestoreDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GamestoreDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.DateModified = DateTime.Now;
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DateModified = DateTime.Now;
                }
            }

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
