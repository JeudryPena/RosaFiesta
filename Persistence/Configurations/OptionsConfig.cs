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
		builder.Property(x => x.Description);
		builder.Property(x => x.Price).IsRequired();
		builder.Property(x => x.EndedAt);
		builder.Property(x => x.QuantityAvaliable).IsRequired();
		builder.Property(x => x.Color);
		builder.Property(x => x.Size);
		builder.Property(x => x.Weight);
		builder.Property(x => x.GenderFor);
		builder.Property(x => x.Material);
		builder.Property(x => x.Condition).IsRequired();
		builder.Property(a => a.IsDeleted).IsRequired();
		builder.HasMany(product => product.Reviews)
			.WithOne()
			.HasForeignKey(review => review.OptionId);
		builder.HasMany(option => option.PurchaseOptions)
			.WithOne()
			.HasForeignKey(purchaseOption => purchaseOption.OptionId);
		builder.HasMany(option => option.Images)
			.WithOne()
			.HasForeignKey(image => image.OptionId);
	}
}