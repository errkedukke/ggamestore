using Gamestore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Persistence.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Description)
            .HasMaxLength(1000);

        builder.Property(c => c.DateCreated)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        builder.Property(c => c.DateModified)
            .IsRequired(false)
            .HasDefaultValue(null);

        builder.Property(c => c.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);
    }
}
