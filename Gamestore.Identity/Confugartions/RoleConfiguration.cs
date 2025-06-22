using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Identity.Confugartions;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "529ba93f-f025-4ac4-b6ed-c652b2a4b8b1",
                Name = "User",
                NormalizedName = "USER",
            },
            new IdentityRole
            {
                Id = "af759fe3-76a0-4000-8467-d504fad652cf",
                Name = "Admin",
                NormalizedName = "ADMIN"
            });
    }
}
