using Gamestore.Domain;
using Gamestore.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Persistence.Configuration
{
    public class GamestoreConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(
                new Game
                {
                    Id = Guid.NewGuid(),
                    Name = "The Witcher 3: Wild Hunt",
                    CategoryId = Guid.NewGuid(),
                    GenreId = Guid.NewGuid(),
                    Platform = Platform.Mac,
                    Price = 49.99m,
                    UnitInStock = 100,
                    Discontinued = false,
                    ReleaseDate = new DateTime(2015, 5, 19),
                    Views = 5000000,
                    Description = "An open-world RPG featuring monster hunting, exploration, and a gripping story.",
                    ImageKey = "witcher3-image"
                },
                new Game
                {
                    Id = Guid.NewGuid(),
                    Name = "Halo Infinite",
                    CategoryId = Guid.NewGuid(),
                    GenreId = Guid.NewGuid(),
                    Platform = Platform.Linux,
                    Price = 59.99m,
                    UnitInStock = 200,
                    Discontinued = false,
                    ReleaseDate = new DateTime(2021, 12, 8),
                    Views = 3000000,
                    Description = "The latest entry in the iconic Halo series, featuring a new campaign and multiplayer modes.",
                    ImageKey = "halo-infinite-image"
                },
                new Game
                {
                    Id = Guid.NewGuid(),
                    Name = "Cyberpunk 2077",
                    CategoryId = Guid.NewGuid(),
                    GenreId = Guid.NewGuid(),
                    Platform = Platform.Windows,
                    Price = 39.99m,
                    UnitInStock = 150,
                    Discontinued = false,
                    ReleaseDate = new DateTime(2020, 12, 10),
                    Views = 8000000,
                    Description = "An open-world RPG set in a dystopian future, with deep narrative and customization options.",
                    ImageKey = "cyberpunk2077-image"
                });
        }
    }
}
