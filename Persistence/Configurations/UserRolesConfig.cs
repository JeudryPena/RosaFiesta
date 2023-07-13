using Domain.Entities.Security;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserRolesConfig : IEntityTypeConfiguration<UserRole>
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

	public void Configure(EntityTypeBuilder<UserRole> builder)
	{
		builder.HasQueryFilter(a => !a.IsDeleted);
		UserRole iur = new UserRole
		{
			
			RoleId = adminRoleId,
			UserId = adminUserId
		};
		UserRole iur2 = new UserRole
		{
			RoleId = clientRoleId,
			UserId = clientUserId
		};
		UserRole iur3 = new UserRole
		{
			RoleId = productsRoleId,
			UserId = productUserId
		};
		UserRole iur4 = new UserRole
		{
			RoleId = salesRoleId,
			UserId = salesUserId
		};
		UserRole iur5 = new UserRole
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