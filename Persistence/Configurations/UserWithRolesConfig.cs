using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    private const string adminUserId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
    private const string adminRoleId = "2301D884-221A-4E7D-B509-0113DCC043E1";
    private const string clientUserId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";
    private const string productUserId = "2301D884-221A-4E7D-B509-0113DCC043E1";
    private const string salesUserId = "2301D884-221A-4E7D-B509-0113DCC043E2";
    private const string marketingUserId = "2301D884-221A-4E7D-B509-0113DCC043E3";
    private const string clientRoleId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";
    private const string productsRoleId = "2301D884-221A-4E7D-B509-0113DCC043E2";
    private const string salesRoleId = "2301D884-221A-4E7D-B509-0113DCC043E3";
    private const string marketingRoleId = "2301D884-221A-4E7D-B509-0113DCC043E4";

    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        IdentityUserRole<string> iur = new IdentityUserRole<string>
        {
            RoleId = adminRoleId,
            UserId = adminUserId
        };
        IdentityUserRole<string> iur2 = new IdentityUserRole<string>
        {
            RoleId = clientRoleId,
            UserId = clientUserId
        };
        IdentityUserRole<string> iur3 = new IdentityUserRole<string>
        {
            RoleId = productsRoleId,
            UserId = productUserId
        };
        IdentityUserRole<string> iur4 = new IdentityUserRole<string>
        {
            RoleId = salesRoleId,
            UserId = salesUserId
        };
        IdentityUserRole<string> iur5 = new IdentityUserRole<string>
        {
            RoleId = marketingRoleId,
            UserId = marketingUserId
        };

        builder.HasData(iur);
        builder.HasData(iur2);
        builder.HasData(iur3);
        builder.HasData(iur4);
        builder.HasData(iur5);
    }
}