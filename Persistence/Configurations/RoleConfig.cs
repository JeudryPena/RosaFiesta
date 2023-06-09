using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class RoleConfig : IEntityTypeConfiguration<IdentityRole>
{
	private const string adminId = "2301D884-221A-4E7D-B509-0113DCC043E1";
	private const string clientId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";
	private const string productsManagerId = "2301D884-221A-4E7D-B509-0113DCC043E2";
	private const string salesManagerId = "2301D884-221A-4E7D-B509-0113DCC043E3";
	private const string marketingManagerId = "2301D884-221A-4E7D-B509-0113DCC043E4";

	public void Configure(EntityTypeBuilder<IdentityRole> builder)
	{
		builder.HasData(
			new IdentityRole
			{
				Id = adminId,
				Name = "Admin",
				NormalizedName = "ADMIN"
			},
			new IdentityRole
			{
				Id = clientId,
				Name = "Client",
				NormalizedName = "CLIENTE"
			},
			new IdentityRole
			{
				Id = productsManagerId,
				Name = "ProductsManager",
				NormalizedName = "PRODUCTSMANAGER"
			},
			new IdentityRole
			{
				Id = salesManagerId,
				Name = "SalesManager",
				NormalizedName = "SALESMANAGER"
			},
			new IdentityRole
			{
				Id = marketingManagerId,
				Name = "MarketingManager",
				NormalizedName = "MARKETINGMANAGER"
			}
		);
	}
}
