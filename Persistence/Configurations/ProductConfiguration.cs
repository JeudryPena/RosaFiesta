using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
	public void Configure(EntityTypeBuilder<ProductEntity> builder)
	{
		builder.HasKey(product => product.Id);
		builder.Property(product => product.Id).IsRequired();
		builder.Property(product => product.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasIndex(product => product.Code).IsUnique();
		builder.HasMany(product => product.Options)
			.WithOne()
			.HasForeignKey(option => option.ProductId)
			.OnDelete(DeleteBehavior.Cascade);
		builder.HasOne(product => product.Option)
			.WithOne()
			.HasForeignKey<ProductEntity>(product => product.OptionId)
			.OnDelete(DeleteBehavior.Cascade);
		builder.HasOne(product => product.Category)
			.WithMany(category => category.Products)
			.HasForeignKey(product => product.CategoryId);
		builder.HasOne(product => product.Warranty)
			.WithMany(x => x.Products)
			.HasForeignKey(product => product.WarrantyId);
		builder.HasMany(product => product.Details)
			.WithOne()
			.HasForeignKey(detail => detail.ProductId);
		builder.HasOne(product => product.Supplier)
			.WithMany(supplier => supplier.Products)
			.HasForeignKey(product => product.SupplierId);

	}
}