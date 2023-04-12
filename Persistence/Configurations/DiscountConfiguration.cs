using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<DiscountEntity>
{
    private const string DefaultDiscountCode = "ROSA";
    private const string DefaultDiscountCode1 = "WELCOME";

    public void Configure(EntityTypeBuilder<DiscountEntity> builder)
    {
        builder.ToTable(nameof(DiscountEntity));
        builder.HasKey(x => x.DiscountCode);
        builder.Property(x => x.DiscountCode).HasMaxLength(20).IsRequired();
        builder.Property(x => x.DiscountName).HasMaxLength(100).IsRequired();
         builder.Property(x => x.DiscountType).IsRequired();
        builder.Property(x => x.DiscountValue).IsRequired();
        builder.Property(x => x.MaxTimesApply).IsRequired();
        builder.Property(x => x.DiscountStartDate).IsRequired();
        builder.Property(x => x.DiscountEndDate).IsRequired();
        builder.Property(x => x.DiscountDescription).HasMaxLength(100);
        builder.Property(x => x.DiscountImage);
        builder.HasMany(x => x.ProductsDiscounts).WithOne().HasForeignKey(x => x.DiscountCode);
        builder.HasMany(x => x.AppliedDiscounts).WithOne().HasForeignKey(x => x.DiscountCode);
        builder.HasData(new DiscountEntity
        {
            DiscountCode = DefaultDiscountCode,
            DiscountName = "Descuento Inicial",
            DiscountValue = 200,
            DiscountType = DiscountType.Amount,
            DiscountStartDate = DateTimeOffset.UtcNow,
            DiscountEndDate = new DateTimeOffset(2023, 9, 30, 0, 0, 0, TimeSpan.Zero),
            DiscountDescription = "10% de descuento en todos los productos",
            DiscountImage = "https://i.imgur.com/1ZQZ1Zm.png",
            MaxTimesApply = 5,
        }, new DiscountEntity {
            DiscountCode = DefaultDiscountCode1,
            DiscountName = "Descuento de Bienvenida",
            DiscountValue = 10,
            DiscountType = DiscountType.Percentage,
            DiscountStartDate = DateTimeOffset.UtcNow,
            DiscountEndDate = new DateTimeOffset(2023, 9, 30, 0, 0, 0, TimeSpan.Zero),
            DiscountDescription = "100$ de descuento en todos los productos",
            DiscountImage = "https://i.imgur.com/1ZQZ1Zm.png",
            MaxTimesApply = 1,         
        }

    );
}
}