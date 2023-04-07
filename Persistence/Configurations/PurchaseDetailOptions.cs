using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PurchaseDetailOptionsConfig: IEntityTypeConfiguration<PurchaseDetailOptions> {
    private const int PurchaseNumberDefault = 1;
    private const int PurchaseNumber2= 2;
    private const int AppliedId = 1;
    private const int AppliedId1 = 2;
    private const int AppliedId2 = 3;
    private const int OptionId = 1;
    private const int OptionId2 = 2;
    private const int OptionId3 = 3;

    public void Configure(EntityTypeBuilder<PurchaseDetailOptions> builder) {
        builder.ToTable(nameof(PurchaseDetailOptions));
        builder.HasKey(x => new {x.PurchaseNumber, x.OptionId});
        builder.Property(x => x.PurchaseNumber);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.UnitPrice).IsRequired();
        builder.Property(x => x.AppliedId);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.OptionId).IsRequired();
        builder.HasOne(x => x.DiscountApplied).WithOne(x => x.PurchaseOption).HasForeignKey<PurchaseDetailOptions>(x => x.AppliedId);
        builder.HasData(new PurchaseDetailOptions {
            PurchaseNumber = PurchaseNumberDefault,
            Quantity = 3,
            UnitPrice = 1200,
            AppliedId = AppliedId,
            CreatedAt = DateTimeOffset.Now,
            OptionId = OptionId
        }, new PurchaseDetailOptions {
            PurchaseNumber = PurchaseNumberDefault,
            Quantity = 4,
            UnitPrice = 800,
            AppliedId = AppliedId1,
            CreatedAt = DateTimeOffset.Now,
            OptionId = OptionId2
        }, new PurchaseDetailOptions {
            PurchaseNumber = PurchaseNumber2,
            Quantity = 2,
            UnitPrice = 800,
            AppliedId = AppliedId2,
            CreatedAt = DateTimeOffset.Now,
            OptionId = OptionId3
        });
    }
}