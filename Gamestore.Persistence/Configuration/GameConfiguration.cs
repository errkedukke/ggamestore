using Gamestore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Persistence.Configuration;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        // Table name (optional)
        builder.ToTable("Games");

        // Primary Key
        builder.HasKey(g => g.Id);

        // Properties Configuration

        // Name: Required, max length of 200 characters
        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(200);

        // Price: Required, precision and scale for decimal
        builder.Property(g => g.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        // UnitInStock: Required
        builder.Property(g => g.UnitInStock)
            .IsRequired();

        // Discontinued: Required, default to false
        builder.Property(g => g.Discontinued)
            .IsRequired()
            .HasDefaultValue(false);

        // ReleaseDate: Required
        builder.Property(g => g.ReleaseDate)
            .IsRequired();

        // Views: Required, default to 0
        builder.Property(g => g.Views)
            .IsRequired()
            .HasDefaultValue(0);

        // Description: Optional, max length of 1000 characters
        builder.Property(g => g.Description)
            .HasMaxLength(1000);

        // ImageKey: Optional, max length of 255 characters
        builder.Property(g => g.ImageKey)
            .HasMaxLength(255);

        // Relationships

        // Category relationship
        builder.HasOne(g => g.Category)
            .WithMany() // Assuming no navigation property in Category for Games
            .HasForeignKey(g => g.CategoryId)
            .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete

        // Genre relationship
        builder.HasOne(g => g.Genre)
            .WithMany() // Assuming no navigation property in Genre for Games
            .HasForeignKey(g => g.GenreId)
            .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete
    }
}
