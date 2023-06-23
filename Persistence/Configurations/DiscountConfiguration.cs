using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<DiscountEntity>
{

	public void Configure(EntityTypeBuilder<DiscountEntity> builder)
	{
		builder.ToTable(nameof(DiscountEntity));
		builder.HasKey(x => x.Code);
		builder.Property(a => a.CreatedAt).IsRequired().ValueGeneratedOnAdd();
		builder.Property(a => a.UpdatedAt).ValueGeneratedOnUpdate();
		builder.HasQueryFilter(x => !x.IsDeleted);
		builder.Property(x => x.Code).IsRequired();
		builder.Property(x => x.Name).IsRequired();
		builder.Property(x => x.Type).IsRequired();
		builder.Property(x => x.Value).IsRequired();
		builder.Property(x => x.MaxTimesApply).IsRequired();
		builder.Property(x => x.Start).IsRequired();
		builder.Property(x => x.End).IsRequired();
		builder.Property(x => x.Description);
		builder.Property(a => a.CreatedAt).IsRequired();
		builder.Property(a => a.UpdatedAt);
		builder.Property(a => a.CreatedBy).IsRequired();
		builder.Property(a => a.UpdatedBy);
		builder.Property(a => a.IsDeleted).IsRequired();
		builder.HasMany(x => x.ProductsDiscounts).WithOne().HasForeignKey(x => x.Code);
		builder.HasMany(x => x.AppliedDiscounts).WithOne().HasForeignKey(x => x.Code);
	}
}