using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<CartEntity>
{
	private const string CartId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
	private const string CartId2 = "7d9b7113-a8f8-4035-99a7-a20dd400f6a3";
	private const string CartId3 = "2301d884-221a-4e7d-b509-0113dcc043e1";
	private const string CartId4 = "2301d884-221a-4e7d-b509-0113dcc043e2";
	private const string CartId5 = "2301d884-221a-4e7d-b509-0113dcc043e3";
	private const string AdminId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
	private const string UserId = "7d9b7113-a8f8-4035-99a7-a20dd400f6a3";
	private const string productManagerId = "2301d884-221a-4e7d-b509-0113dcc043e1";
	private const string salesManagerId = "2301d884-221a-4e7d-b509-0113dcc043e2";
	private const string marketingManagerId = "2301d884-221a-4e7d-b509-0113dcc043e3";
	public void Configure(EntityTypeBuilder<CartEntity> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.HasMany(x => x.Details).WithOne(x => x.Cart).HasForeignKey(x => x.CartId);
		builder.HasData(new CartEntity
		{
			Id = Guid.Parse(CartId),
			UserId = AdminId,
		});
		builder.HasData(new CartEntity
		{
			Id = Guid.Parse(CartId2),
			UserId = UserId,
		});
		builder.HasData(new CartEntity
		{
			Id = Guid.Parse(CartId3),
			UserId = productManagerId,
		});
		builder.HasData(new CartEntity
		{
			Id = Guid.Parse(CartId4),
			UserId = salesManagerId,
		});
		builder.HasData(new CartEntity
		{
			Id = Guid.Parse(CartId5),
			UserId = marketingManagerId,
		});
	}
}