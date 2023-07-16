using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OptionsConfig : IEntityTypeConfiguration<OptionEntity>
{
	public void Configure(EntityTypeBuilder<OptionEntity> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasMany(product => product.Reviews)
			.WithOne()
			.HasForeignKey(review => review.OptionId);
		builder.HasMany(option => option.PurchaseOptions)
			.WithOne()
			.HasForeignKey(purchaseOption => purchaseOption.OptionId);
		builder.HasMany(option => option.Images)
			.WithOne()
			.HasForeignKey(image => image.OptionId);
		builder.HasOne(x => x.Image)
			.WithOne()
			.HasForeignKey<OptionEntity>(x => x.ImageId);
	}
}