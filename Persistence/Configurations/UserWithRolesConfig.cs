using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    private const string adminUserId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
    private const string adminRoleId = "2301D884-221A-4E7D-B509-0113DCC043E1";

    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        IdentityUserRole<string> iur = new IdentityUserRole<string>
        {
            RoleId = adminRoleId,
            UserId = adminUserId
        };

        builder.HasData(iur);
    }
}