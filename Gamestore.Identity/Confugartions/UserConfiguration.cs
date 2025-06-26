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
        // Password!123

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
                 PasswordHash = "AQAAAAIAAYagAAAAEK+Oj+7hQWcp96oKmNIRSN2GNvsgHCGh7FKOwO7tqV+RPiVizICDLovbibhTgV8fFg==",
                 ConcurrencyStamp = "1fdb4a52-b4dd-4575-b867-5eccaa151cf9",
                 SecurityStamp = "84769241-a049-4770-92be-b9848a106367"
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
                PasswordHash = "AQAAAAIAAYagAAAAEK+Oj+7hQWcp96oKmNIRSN2GNvsgHCGh7FKOwO7tqV+RPiVizICDLovbibhTgV8fFg==",
                ConcurrencyStamp = "1fdb4a52-b4dd-4575-b867-5eccaa151cf9",
                SecurityStamp = "84769241-a049-4770-92be-b9848a106367"
            }
        );
    }

}
