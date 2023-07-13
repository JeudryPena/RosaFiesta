using Domain.Entities.Security;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class RoleConfig : IEntityTypeConfiguration<RoleEntity>
{
	private const string adminId = "2301D884-221A-4E7D-B509-0113DCC043E1";
	private const string clientId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";
	private const string productsManagerId = "2301D884-221A-4E7D-B509-0113DCC043E2";
	private const string salesManagerId = "2301D884-221A-4E7D-B509-0113DCC043E3";
	private const string marketingManagerId = "2301D884-221A-4E7D-B509-0113DCC043E4";

	public void Configure(EntityTypeBuilder<RoleEntity> builder)
	{
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasData(
			new RoleEntity
			{
				Id = adminId,
				Name = "Admin",
				NormalizedName = "ADMIN"
			},
			new RoleEntity
			{
				Id = clientId,
				Name = "Client",
				NormalizedName = "CLIENT"
			},
			new RoleEntity
			{
				Id = productsManagerId,
				Name = "ProductsManager",
				NormalizedName = "PRODUCTSMANAGER"
			},
			new RoleEntity
			{
				Id = salesManagerId,
				Name = "SalesManager",
				NormalizedName = "SALESMANAGER"
			},
			new RoleEntity
			{
				Id = marketingManagerId,
				Name = "MarketingManager",
				NormalizedName = "MARKETINGMANAGER"
			}
		);
	}
}
