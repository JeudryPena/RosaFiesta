using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ProductsDiscountsConfig : IEntityTypeConfiguration<ProductsDiscountsEntity>
{
	public void Configure(EntityTypeBuilder<ProductsDiscountsEntity> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasOne(p => p.Discount)
		 .WithMany(x => x.ProductsDiscounts)
		 .HasForeignKey(p => p.DiscountId);
		builder.HasOne(x => x.Option).WithMany(x => x.ProductsDiscounts).HasForeignKey(x => x.OptionId);
	}
}