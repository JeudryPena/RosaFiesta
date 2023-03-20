using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AppliedDiscountConfig : IEntityTypeConfiguration<AppliedDiscountEntity>
{
    private const string DefaultDiscountCode = "ROSA";
    private const string AdminId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
    private const string DefaultDiscountCode1 = "WELCOME";
    private const int AppliedId = 1;
    private const int AppliedId1 = 2;
    private const int PurchaseNumberDefault = 1;
    private const int PurchaseNumber2= 2;
    public void Configure(EntityTypeBuilder<AppliedDiscountEntity> builder)
    {
        builder.HasKey(ad => ad.Id);
        builder.Property(ad => ad.Id).ValueGeneratedOnAdd();
        builder.Property(ad => ad.AppliedDate).IsRequired();
        builder.Property(ad => ad.UserId).IsRequired();
        builder.Property(ad => ad.DiscountCode).IsRequired();
        builder.Property(ad => ad.PurchaseNumber).IsRequired();
        builder.HasOne(ad => ad.User).WithMany(u => u.AppliedDiscounts).HasForeignKey(ad => ad.UserId);
        builder.HasOne(ad => ad.Discount).WithMany(d => d.AppliedDiscounts).HasForeignKey(ad => ad.DiscountCode);
        builder.HasOne(ad => ad.PurchaseDetail).WithOne(pd => pd.DiscountApplied).HasForeignKey<AppliedDiscountEntity>(ad => ad.PurchaseNumber);
        builder.HasData(new AppliedDiscountEntity
        {
            Id = AppliedId,
            UserId = AdminId,
            DiscountCode = DefaultDiscountCode,
            AppliedDate = DateTimeOffset.Now,
            PurchaseNumber = PurchaseNumberDefault
        }, new AppliedDiscountEntity
            {
                Id = AppliedId1,
                UserId = AdminId,
                DiscountCode = DefaultDiscountCode1,
                AppliedDate = DateTimeOffset.Now,
                PurchaseNumber = PurchaseNumber2
            }
        );
    }
}