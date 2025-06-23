using Gamestore.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Identity.Confugartions;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(
             new ApplicationUser
             {
                 Id = "c99e2f6b-f470-4c4c-a347-9653d6c3870a",
                 UserName = "user",
                 NormalizedUserName = "USER",
                 Firstname = "User",
                 Lastname = "Regularuser",
                 Email = "user@example.com",
                 NormalizedEmail = "USER@EXAMPLE.COM",
                 EmailConfirmed = true,
                 PasswordHash = "AQAAAAEAACcQAAAAEGGLGr1PBvJGoRcr0GfGlPlPtM5k6FtK8uXU+uS8THl9dB6FzBTJkaEkVcuRNe+QkA==",
             },
            new ApplicationUser
            {
                Id = "3e5f8b62-2c61-4c09-b7c1-5e3f6de79f1c",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Firstname = "System",
                Lastname = "Administrator",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEGGLGr1PBvJGoRcr0GfGlPlPtM5k6FtK8uXU+uS8THl9dB6FzBTJkaEkVcuRNe+QkA==",
            }
        );
    }

}
