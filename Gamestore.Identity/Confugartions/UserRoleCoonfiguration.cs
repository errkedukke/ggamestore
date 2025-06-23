using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Identity.Confugartions;

public class UserRoleCoonfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "529ba93f-f025-4ac4-b6ed-c652b2a4b8b1",
                UserId = "c99e2f6b-f470-4c4c-a347-9653d6c3870a",
            },
           new IdentityUserRole<string>
           {
               RoleId = "af759fe3-76a0-4000-8467-d504fad652cf",
               UserId = "3e5f8b62-2c61-4c09-b7c1-5e3f6de79f1c",
           });
    }
}
