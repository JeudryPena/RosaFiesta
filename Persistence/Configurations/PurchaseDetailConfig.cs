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
    private const int CartId = 1;

    public void Configure(EntityTypeBuilder<PurchaseDetailEntity> builder)
    {
        builder.ToTable(nameof(PurchaseDetailEntity));
        builder.HasKey(x => new { x.PurchaseNumber});
        builder.Property(x => x.PurchaseNumber).ValueGeneratedOnAdd();
        builder.Property(x => x.CartId).IsRequired();
        builder.Property(x => x.OrderSku);
        builder.HasMany(x => x.PurchaseOptions).WithOne().HasForeignKey(x => x.PurchaseNumber);
        builder.HasData(
            new PurchaseDetailEntity
            {
                PurchaseNumber = PurchaseNumberDefault,
                ProductId = ProductId,
                CartId = CartId,
            },
            new PurchaseDetailEntity
            {
                PurchaseNumber = PurchaseNumber2,
                ProductId = ProductId2,
                CartId = CartId,
            });
    }
}