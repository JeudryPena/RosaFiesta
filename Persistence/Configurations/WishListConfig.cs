using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class WishListConfig : IEntityTypeConfiguration<WishListEntity>
{
    
	private const string WishListId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
	private const string WishListId2 = "7d9b7113-a8f8-4035-99a7-a20dd400f6a3";
	private const string WishListId3 = "2301d884-221a-4e7d-b509-0113dcc043e1";
	private const string WishListId4 = "2301d884-221a-4e7d-b509-0113dcc043e2";
	private const string WishListId5 = "2301d884-221a-4e7d-b509-0113dcc043e3";
	private const string AdminId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
	private const string UserId = "7d9b7113-a8f8-4035-99a7-a20dd400f6a3";
	private const string ProductManagerId = "2301d884-221a-4e7d-b509-0113dcc043e1";
	private const string SalesManagerId = "2301d884-221a-4e7d-b509-0113dcc043e2";
	private const string MarketingManagerId = "2301d884-221a-4e7d-b509-0113dcc043e3";
	
	public void Configure(EntityTypeBuilder<WishListEntity> builder)
	{
		builder.HasKey(w => w.Id);
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasMany(x => x.ProductsWish)
			.WithOne()
			.HasForeignKey(x => x.WishListId);
		builder.HasData(new WishListEntity
		{
			Id = Guid.Parse(WishListId),
			UserId = AdminId,
		});
		builder.HasData(new WishListEntity
		{
			Id = Guid.Parse(WishListId2),
			UserId = UserId,
		});
		builder.HasData(new WishListEntity
		{
			Id = Guid.Parse(WishListId3),
			UserId = ProductManagerId,
		});
		builder.HasData(new WishListEntity
		{
			Id = Guid.Parse(WishListId4),
			UserId = SalesManagerId,
		});
		builder.HasData(new WishListEntity
		{
			Id = Guid.Parse(WishListId5),
			UserId = MarketingManagerId,
		});
	}
}