using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<DiscountEntity>
{
    private const string DefaultDiscountCode = "ROSA";
    
    public void Configure(EntityTypeBuilder<DiscountEntity> builder)
    {
        builder.ToTable(nameof(DiscountEntity));
        builder.HasKey(x => x.DiscountCode);
        builder.Property(x => x.DiscountName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.DiscountType).IsRequired();
        builder.Property(x => x.Discount).IsRequired();
        builder.Property(x => x.DiscountStartDate).IsRequired();
        builder.Property(x => x.DiscountEndDate).IsRequired();
        builder.Property(x => x.DiscountDescription).HasMaxLength(100);
        builder.Property(x => x.DiscountImage);
        builder.Property(x => x.DiscountCodeImage).HasMaxLength(500);
        builder.HasData(new DiscountEntity
        {
            DiscountCode = DefaultDiscountCode,
            DiscountName = "Descuento Inicial",
            DiscountType = DiscountType.Percentage,
            Discount = 10,
            DiscountStartDate = DateTimeOffset.UtcNow,
            DiscountEndDate = new DateTimeOffset(2023, 9, 30, 0, 0, 0, TimeSpan.Zero),
            DiscountDescription = "10% de descuento en todos los productos",
            DiscountImage = "https://i.imgur.com/1ZQZ1Zm.png",
            DiscountCodeImage = "https://i.imgur.com/1ZQZ1Zm.png"
        });
    }
}