using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
	private const string ProductId = "SDA01";
	private const string ProductId2 = "SDA02";
	private const int CategoryId = 1;
	private const string WarrantyId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F6";
	private const string SupplierId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F9";

	public void Configure(EntityTypeBuilder<ProductEntity> builder)
	{
		builder.HasKey(product => product.Code);
		builder.Property(product => product.Code).IsRequired();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasMany(product => product.Options)
			.WithOne()
			.HasForeignKey(option => option.ProductCode)
			.OnDelete(DeleteBehavior.Cascade);
		builder.HasOne(product => product.Category)
			.WithMany(category => category.Products)
			.HasForeignKey(product => product.CategoryId);
		builder.HasOne(product => product.Warranty)
			.WithMany()
			.HasForeignKey(product => product.WarrantyId);
		builder.HasMany(product => product.Details)
			.WithOne()
			.HasForeignKey(detail => detail.ProductId);
		builder.HasOne(product => product.Supplier)
			.WithMany(supplier => supplier.ProductsSupplied)
			.HasForeignKey(product => product.SupplierId);
	}
}