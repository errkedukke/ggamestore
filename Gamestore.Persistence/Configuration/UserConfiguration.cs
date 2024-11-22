using Gamestore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Table name (optional)
        builder.ToTable("Users");

        // Primary Key
        builder.HasKey(u => u.Id);

        // Properties Configuration

        // Firstname: Required, max length 100
        builder.Property(u => u.Firstname)
            .IsRequired()
            .HasMaxLength(100);

        // Lastname: Required, max length 100
        builder.Property(u => u.Lastname)
            .IsRequired()
            .HasMaxLength(100);

        // Email: Required, max length 255, unique
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(u => u.Email)
            .IsUnique();

        // PasswordHash: Required
        builder.Property(u => u.PasswordHash)
            .IsRequired();

        // MobileNumber: Optional, max length 20
        builder.Property(u => u.MobileNumber)
            .HasMaxLength(20);
    }
}
