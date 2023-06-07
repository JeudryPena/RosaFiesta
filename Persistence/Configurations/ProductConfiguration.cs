using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;

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
        builder.ToTable(nameof(ProductEntity));
        builder.HasKey(product => product.Code);
        builder.Property(product => product.Code).IsRequired();
        builder.Property(product => product.Title).IsRequired();
        builder.Property(product => product.Brand);
        builder.Property(product => product.Type).IsRequired();

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
        builder.HasMany(product => product.Discounts)
            .WithOne()
            .HasForeignKey(discount => discount.ProductId);

        builder.HasData(
            new ProductEntity
            {
                Code = ProductId,
                Title = "Polo",
                Brand = "Champion",
                Type = ProductType.Physical,
                CategoryId = CategoryId,
                WarrantyId = Guid.Parse(WarrantyId),
                SupplierId = Guid.Parse(SupplierId),
            },
            new ProductEntity
            {
                Code = ProductId2,
                Title = "Flores",
                Brand = "Flores",
                Type = ProductType.Physical,
                CategoryId = CategoryId,
                WarrantyId = Guid.Parse(WarrantyId),
                SupplierId = Guid.Parse(SupplierId),
            }
        );
    }
}