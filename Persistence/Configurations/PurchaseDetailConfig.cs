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
    public const int OrderSku = 1;
    
    public void Configure(EntityTypeBuilder<PurchaseDetailEntity> builder)
    {
        builder.ToTable(nameof(PurchaseDetailEntity));
        builder.HasKey(x => new { x.PurchaseNumber, x.ProductId});
        builder.Property(x => x.PurchaseNumber).ValueGeneratedOnAdd();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.UnitPrice);
        builder.Property(x => x.DiscountId);
        builder.Property(x => x.CartId).IsRequired();
        builder.HasOne(x => x.DiscountApplied).WithMany(x => x.DiscountPurchases).HasForeignKey(x => x.DiscountId);
        builder.HasOne(x => x.Product).WithMany(x => x.Details).HasForeignKey(x => x.ProductId);
        builder.HasOne(x => x.Cart).WithMany(x => x.Details).HasForeignKey(x => x.CartId);

        builder.HasData(
            new PurchaseDetailEntity
            {
                PurchaseNumber = PurchaseNumberDefault,
                ProductId = ProductId,
                Quantity = 2,
                UnitPrice = 1000,
                DiscountId = DefaultDiscountCode,
                CartId = 1
            }
        );
    }
}