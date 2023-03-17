using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AppliedDiscountConfig : IEntityTypeConfiguration<AppliedDiscountEntity>
{
    public void Configure(EntityTypeBuilder<AppliedDiscountEntity> builder)
    {
        builder.HasKey(ad => ad.Id);
        builder.Property(ad => ad.Id).ValueGeneratedOnAdd();
        builder.Property(ad => ad.TimesApplied).IsRequired();
        builder.Property(ad => ad.AppliedDate).IsRequired();
        builder.HasOne(ad => ad.User).WithMany(u => u.AppliedDiscounts).HasForeignKey(ad => ad.UserId);
        builder.HasOne(ad => ad.Discount).WithMany(d => d.AppliedDiscounts).HasForeignKey(ad => ad.DiscountCode);
        builder.HasOne(ad => ad.Order).WithMany(o => o.AppliedDiscounts).HasForeignKey(ad => ad.OrderId);
    }
}