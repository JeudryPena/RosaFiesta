using Domain.Entities.Security;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class RoleConfig : IEntityTypeConfiguration<RoleEntity>
{
	private const string adminRoleId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
	private const string clientRoleId = "7d9b7113-a8f8-4035-99a7-a20dd400f6a3";
	private const string productsRoleId = "2301d884-221a-4e7d-b509-0113dcc043e1";
	private const string salesRoleId = "2301d884-221a-4e7d-b509-0113dcc043e2";
	private const string marketingRoleId = "2301d884-221a-4e7d-b509-0113dcc043e3";

	public void Configure(EntityTypeBuilder<RoleEntity> builder)
	{
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasData(
			new RoleEntity
			{
				Id = adminRoleId,
				Name = "Admin",
				NormalizedName = "ADMIN"
			},
			new RoleEntity
			{
				Id = clientRoleId,
				Name = "Client",
				NormalizedName = "CLIENT"
			},
			new RoleEntity
			{
				Id = productsRoleId,
				Name = "ProductsManager",
				NormalizedName = "PRODUCTSMANAGER"
			},
			new RoleEntity
			{
				Id = salesRoleId,
				Name = "SalesManager",
				NormalizedName = "SALESMANAGER"
			},
			new RoleEntity
			{
				Id = marketingRoleId,
				Name = "MarketingManager",
				NormalizedName = "MARKETINGMANAGER"
			}
		);
	}
}
