using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PurchaseDetailConfig : IEntityTypeConfiguration<PurchaseDetailEntity>
{
    public void Configure(EntityTypeBuilder<PurchaseDetailEntity> builder)
    {
        builder.ToTable(nameof(PurchaseDetailEntity));
        builder.HasKey(x => new { x.PurchaseNumber, x.BillId });
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.UnitPrice);
        builder.HasOne(x => x.DiscountApplied).WithMany(x => x.DiscountPurchases).HasForeignKey(x => x.DiscountId);
    }
}