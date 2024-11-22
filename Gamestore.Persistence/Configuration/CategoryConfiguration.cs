using Gamestore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Persistence.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Table name (optional)
        builder.ToTable("Categories");

        // Primary Key (Inherited from BaseEntity, but it's always good to explicitly set it)
        builder.HasKey(c => c.Id);

        // Properties Configuration

        // CategoryName: Required, max length of 100 characters
        builder.Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(100);

        // Description: Optional, max length of 1000 characters
        builder.Property(c => c.Description)
            .HasMaxLength(1000);

        // DateCreated: No need to configure unless you want specific behavior like default value
        builder.Property(c => c.DateCreated)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()"); // Default to current date/time on insert (for SQL Server)

        // DateModified: Optional, set it to nullable DateTime
        builder.Property(c => c.DateModified)
            .IsRequired(false)
            .HasDefaultValue(null);

        // IsDeleted: Optional, default to false
        builder.Property(c => c.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false); // This is usually false unless soft delete is applied
    }
}
