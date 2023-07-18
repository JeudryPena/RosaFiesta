using Domain.Entities.Security;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserRolesConfig : IEntityTypeConfiguration<UserRole>
{
	private const string adminUserId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
	private const string userId = "7d9b7113-a8f8-4035-99a7-a20dd400f6a3";
	private const string productManagerId = "2301d884-221a-4e7d-b509-0113dcc043e1";
	private const string salesManagerId = "2301d884-221a-4e7d-b509-0113dcc043e2";
	private const string marketingManagerId = "2301d884-221a-4e7d-b509-0113dcc043e3";

	private const string adminRoleId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
	private const string clientRoleId = "7d9b7113-a8f8-4035-99a7-a20dd400f6a3";
	private const string productsRoleId = "2301d884-221a-4e7d-b509-0113dcc043e1";
	private const string salesRoleId = "2301d884-221a-4e7d-b509-0113dcc043e2";
	private const string marketingRoleId = "2301d884-221a-4e7d-b509-0113dcc043e3";

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
			UserId = userId,
		};
		UserRole iur3 = new UserRole
		{
			RoleId = productsRoleId,
			UserId = productManagerId
		};
		UserRole iur4 = new UserRole
		{
			RoleId = salesRoleId,
			UserId = salesManagerId
		};
		UserRole iur5 = new UserRole
		{
			RoleId = marketingRoleId,
			UserId = marketingManagerId
		};

		builder.HasData(iur);
		builder.HasData(iur2);
		builder.HasData(iur3);
		builder.HasData(iur4);
		builder.HasData(iur5);
	}
}