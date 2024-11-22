using Gamestore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Persistence.Configuration;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        // Table name (optional)
        builder.ToTable("Genres");

        // Primary Key
        builder.HasKey(g => g.Id);

        // Properties Configuration

        // Name: Required, max length of 100 characters
        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Relationships

        // Self-referencing relationship (Parent-Child Genre)
        builder.HasOne(g => g.Parent)
            .WithMany() // Assuming no collection property for child genres in Parent
            .HasForeignKey(g => g.ParentId)
            .OnDelete(DeleteBehavior.NoAction); // Prevent cascading deletes
    }
}
