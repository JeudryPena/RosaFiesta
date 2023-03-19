using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PurchaseDetailConfig : IEntityTypeConfiguration<PurchaseDetailEntity>
{
    public const int PurchaseNumberDefault = 1;
    public const int PurchaseNumber2= 2;
    private const string ProductId = "SDA01";
    private const string ProductId2 = "SDA02";
    private const string DefaultDiscountCode = "ROSA";
    private const string DefaultDiscountCode1 = "WELCOME";
    public const int CartId = 1;

    public void Configure(EntityTypeBuilder<PurchaseDetailEntity> builder)
    {
        builder.ToTable(nameof(PurchaseDetailEntity));
        builder.HasKey(x => new { x.PurchaseNumber, x.ProductId});
        builder.Property(x => x.PurchaseNumber).ValueGeneratedOnAdd();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.UnitPrice);
        builder.Property(x => x.DiscountCode);
        builder.Property(x => x.CartId).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.OrderSku);
        builder.HasOne(x => x.DiscountApplied).WithMany(x => x.DiscountPurchases).HasForeignKey(x => x.DiscountCode);
        builder.HasOne(x => x.Product).WithMany(x => x.Details).HasForeignKey(x => x.ProductId);
        builder.HasOne(x => x.Order).WithMany(x => x.Details).HasForeignKey(x => x.OrderSku);
        builder.HasData(
            new PurchaseDetailEntity
            {
                PurchaseNumber = PurchaseNumberDefault,
                ProductId = ProductId,
                Quantity = 2,
                UnitPrice = 1000,
                DiscountCode = DefaultDiscountCode,
                CartId = CartId,
                CreatedAt = DateTimeOffset.UtcNow,
            },
            new PurchaseDetailEntity
            {
                PurchaseNumber = PurchaseNumber2,
                ProductId = ProductId2,
                Quantity = 1,
                UnitPrice = 500,
                DiscountCode = DefaultDiscountCode1,
                CartId = CartId,
                CreatedAt = DateTimeOffset.UtcNow,
            }
        );
    }
}