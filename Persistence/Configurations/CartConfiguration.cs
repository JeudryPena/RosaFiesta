using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<CartEntity>
{
	private const int CartId = 1;
	private const int CartId2 = 2;
	private const int CartId3 = 3;
	private const int CartId4 = 4;
	private const int CartId5 = 5;
	private const string AdminId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
	private const string UserId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";
	private const string productManagerId = "2301D884-221A-4E7D-B509-0113DCC043E1";
	private const string salesManagerId = "2301D884-221A-4E7D-B509-0113DCC043E2";
	private const string marketingManagerId = "2301D884-221A-4E7D-B509-0113DCC043E3";
	public void Configure(EntityTypeBuilder<CartEntity> builder)
	{
		builder.ToTable(nameof(CartEntity));
		builder.HasKey(x => x.CartId);
		builder.Property(x => x.CartId).ValueGeneratedOnAdd();
		builder.Property(x => x.UserId).IsRequired();
		builder.HasMany(x => x.Details).WithOne().HasForeignKey(x => x.CartId);
		builder.HasData(new CartEntity
		{
			CartId = CartId,
			UserId = AdminId,
		});
		builder.HasData(new CartEntity
		{
			CartId = CartId2,
			UserId = UserId,
		});
		builder.HasData(new CartEntity
		{
			CartId = CartId3,
			UserId = productManagerId,
		});
		builder.HasData(new CartEntity
		{
			CartId = CartId4,
			UserId = salesManagerId,
		});
		builder.HasData(new CartEntity
		{
			CartId = CartId5,
			UserId = marketingManagerId,
		});
	}
}