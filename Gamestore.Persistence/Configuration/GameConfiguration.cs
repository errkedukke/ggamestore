using Gamestore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Persistence.Configuration;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Games");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(g => g.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(g => g.UnitInStock)
            .IsRequired();

        builder.Property(g => g.Discontinued)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(g => g.ReleaseDate)
            .IsRequired();

        builder.Property(g => g.Views)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(g => g.Description)
            .HasMaxLength(1000);

        builder.Property(g => g.ImageKey)
            .HasMaxLength(255);

        builder.HasOne(g => g.Category)
            .WithMany()
            .HasForeignKey(g => g.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(g => g.Genre)
            .WithMany()
            .HasForeignKey(g => g.GenreId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
