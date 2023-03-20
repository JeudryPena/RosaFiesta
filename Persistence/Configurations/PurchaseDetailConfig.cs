using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PurchaseDetailConfig : IEntityTypeConfiguration<PurchaseDetailEntity>
{
    private const int PurchaseNumberDefault = 1;
    private const int PurchaseNumber2= 2;
    private const string ProductId = "SDA01";
    private const string ProductId2 = "SDA02";
    private const int AppliedId = 1;
    private const int AppliedId1 = 2;
    private const int CartId = 1;

    public void Configure(EntityTypeBuilder<PurchaseDetailEntity> builder)
    {
        builder.ToTable(nameof(PurchaseDetailEntity));
        builder.HasKey(x => new { x.PurchaseNumber, x.ProductId});
        builder.Property(x => x.PurchaseNumber).ValueGeneratedOnAdd();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.UnitPrice);
        builder.Property(x => x.CartId).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.OrderSku);
        builder.HasOne(x => x.DiscountApplied).WithOne(x => x.PurchaseDetail).HasForeignKey<AppliedDiscountEntity>(x => x.PurchaseNumber);
        builder.HasOne(x => x.Product).WithMany(x => x.Details).HasForeignKey(x => x.ProductId);
        builder.HasOne(x => x.Order).WithMany(x => x.Details).HasForeignKey(x => x.OrderSku);
        builder.HasData(
            new PurchaseDetailEntity
            {
                PurchaseNumber = PurchaseNumberDefault,
                ProductId = ProductId,
                Quantity = 2,
                UnitPrice = 1000,
                CartId = CartId,
                CreatedAt = DateTimeOffset.UtcNow,
            },
            new PurchaseDetailEntity
            {
                PurchaseNumber = PurchaseNumber2,
                ProductId = ProductId2,
                Quantity = 1,
                UnitPrice = 500,
                CartId = CartId,
                CreatedAt = DateTimeOffset.UtcNow,
            }
        );
    }
}