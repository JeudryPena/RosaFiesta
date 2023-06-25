using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class WishListConfig : IEntityTypeConfiguration<WishListEntity>
{
	public void Configure(EntityTypeBuilder<WishListEntity> builder)
	{
		builder.HasKey(w => w.Id);
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasMany(x => x.ProductsWish)
			.WithOne()
			.HasForeignKey(x => x.WishListId);

	}
}