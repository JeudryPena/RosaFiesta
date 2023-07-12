using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<DiscountEntity>
{

	public void Configure(EntityTypeBuilder<DiscountEntity> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasQueryFilter(x => !x.IsDeleted);
		builder.HasMany(x => x.ProductsDiscounts).WithOne().HasForeignKey(x => x.DiscountId);
	}
}