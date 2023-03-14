using Domain.Entities;
using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProductConfiguration: IEntityTypeConfiguration<ProductEntity>
{
    private const string ProductId = "SDA01";
    private const int CategoryId = 1;
    private const string WarrantyId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F6";
    private const string SupplierId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F9";

    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable(nameof(ProductEntity));
        builder.HasKey(product => product.Code);
        builder.Property(product => product.Name).HasMaxLength(40).IsRequired();
        builder.Property(product => product.Description).HasMaxLength(200);
        builder.Property(product => product.Price).IsRequired();
        builder.Property(product => product.EndedAt);
        builder.Property(product => product.Image).HasMaxLength(500);
        builder.Property(product => product.Stock).IsRequired();
        builder.Property(product => product.QuantityAvaliable);
        builder.Property(product => product.Brand).HasMaxLength(40);
        builder.Property(product => product.Color).HasMaxLength(15);
        builder.Property(product => product.Size);
        builder.Property(product => product.GenderFor);
        builder.Property(product => product.Material);
        builder.Property(product => product.Type).IsRequired();
        builder.Property(product => product.Condition).IsRequired();
        builder.Property(product => product.CreatedAt).IsRequired();
        builder.Property(product => product.UpdatedAt);
        builder.Property(product => product.CreatedBy);
        builder.Property(product => product.UpdatedBy);
        builder.HasOne(product => product.Category)
            .WithMany(category => category.Products)
            .HasForeignKey(product => product.CategoryId);
        builder.HasOne(product => product.DiscountApplied)
            .WithMany(discount => discount.DiscountProducts)
            .HasForeignKey(product => product.DiscountAppliedId);
        builder.HasOne(product => product.Warranty)
            .WithMany(warranty => warranty.Products)
            .HasForeignKey(product => product.WarrantyId);
        builder.HasMany(product => product.Details)
            .WithOne(detail => detail.Product)
            .HasForeignKey(detail => detail.ProductId);
        builder.HasOne(product => product.Supplier)
            .WithMany(supplier => supplier.ProductsSupplied)
            .HasForeignKey(product => product.SupplierId);
        builder.HasMany(product => product.Reviews)
            .WithOne(review => review.ProductEntity)
            .HasForeignKey(review => review.ProductId);
        builder.HasData(
            new ProductEntity
            {
                Code = ProductId,
                Name = "Polo",
                Description = "Polo de manga corta",
                Price = 1000,
                EndedAt = null, 
                Image =  "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.amazon.com%2FChampion-Reverse-Weave-Polo-White%2Fdp%2FB07G1J7Q2Q&psig=AOvVaw2D5N7VQ2v0uL7zS9O4yJ7l&ust=1628125928634000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCOjGqfCg1_ICFQAAAAAdAAAAABAD",
                Stock = StockStatusType.InStock,
                QuantityAvaliable = 1,
                Brand = "Champion",
                Color = "White",
                Size = 1.5f,
                GenderFor = GenderType.Both,
                Material = MaterialType.Cotton,
                Type = ProductType.Physical,
                Condition = ConditionType.New,
                CategoryId = CategoryId,
                DiscountAppliedId = null,
                Reviews = null,
                WarrantyId = Guid.Parse(WarrantyId),
                SupplierId = Guid.Parse(SupplierId),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                CreatedBy = "Admin",
                UpdatedBy = null
            });
    }
}