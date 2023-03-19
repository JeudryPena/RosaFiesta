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
    public void Configure(EntityTypeBuilder<AppliedDiscountEntity> builder)
    {
        builder.HasKey(ad => ad.Id);
        builder.Property(ad => ad.Id).ValueGeneratedOnAdd();
        builder.Property(ad => ad.TimesApplied).IsRequired();
        builder.Property(ad => ad.AppliedDate).IsRequired();
        builder.HasOne(ad => ad.User).WithMany(u => u.AppliedDiscounts).HasForeignKey(ad => ad.UserId);
        builder.HasOne(ad => ad.Discount).WithMany(d => d.AppliedDiscounts).HasForeignKey(ad => ad.DiscountCode);
        builder.HasData(new AppliedDiscountEntity
        {
            Id = AppliedId,
            UserId = AdminId,
            DiscountCode = DefaultDiscountCode,
            TimesApplied = 2,
            AppliedDate = DateTimeOffset.Now,
        }, new AppliedDiscountEntity
            {
                Id = AppliedId1,
                UserId = AdminId,
                DiscountCode = DefaultDiscountCode1,
                TimesApplied = 1,
                AppliedDate = DateTimeOffset.Now,
            }
        );
    }
}