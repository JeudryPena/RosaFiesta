using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<CartEntity>
{
	private const string CartId = "2301D884-221A-4E7D-B509-0113DCC043E3";
	private const string CartId2 = "2301D884-221A-4E7D-B509-0113DCC043E2";
	private const string CartId3 = "2301D884-221A-4E7D-B509-0113DCC043E1";
	private const string CartId4 = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";
	private const string CartId5 = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
	private const string AdminId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
	private const string UserId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";
	private const string productManagerId = "2301D884-221A-4E7D-B509-0113DCC043E1";
	private const string salesManagerId = "2301D884-221A-4E7D-B509-0113DCC043E2";
	private const string marketingManagerId = "2301D884-221A-4E7D-B509-0113DCC043E3";
	public void Configure(EntityTypeBuilder<CartEntity> builder)
	{
		builder.HasKey(x => x.CartId);
		builder.Property(x => x.CartId).ValueGeneratedOnAdd();
		builder.HasMany(x => x.Details).WithOne().HasForeignKey(x => x.CartId);
		builder.HasData(new CartEntity
		{
			CartId = Guid.Parse(CartId),
			UserId = AdminId,
		});
		builder.HasData(new CartEntity
		{
			CartId = Guid.Parse(CartId2),
			UserId = UserId,
		});
		builder.HasData(new CartEntity
		{
			CartId = Guid.Parse(CartId3),
			UserId = productManagerId,
		});
		builder.HasData(new CartEntity
		{
			CartId = Guid.Parse(CartId4),
			UserId = salesManagerId,
		});
		builder.HasData(new CartEntity
		{
			CartId = Guid.Parse(CartId5),
			UserId = marketingManagerId,
		});
	}
}