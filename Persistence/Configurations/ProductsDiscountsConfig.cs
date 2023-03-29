using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ProductsDiscountsConfig: IEntityTypeConfiguration<ProductsDiscountsEntity>
{
    private const string DefaultDiscountCode = "ROSA";
    private const string DefaultDiscountCode1 = "WELCOME";
    private const string ProductId = "SDA01";
    private const string ProductId2 = "SDA02";
    private const int OptionId = 1;
    private const int OptionId2 = 2;
    public void Configure(EntityTypeBuilder<ProductsDiscountsEntity> builder)
    {
        builder.ToTable(nameof(ProductsDiscountsEntity));
        builder.HasKey(x => new {x.ProductCode, x.DiscountCode});
        builder.HasOne(x => x.Product).WithMany(x => x.Discounts).HasForeignKey(x => x.ProductCode);
        builder.HasOne(x => x.Discount).WithMany(x => x.Products).HasForeignKey(x => x.DiscountCode);
        builder.HasOne(x => x.Option).WithMany(x => x.ProductsDiscounts).HasForeignKey(x => x.OptionId);
        builder.HasData(
            new ProductsDiscountsEntity
            {
                ProductCode = ProductId,
                DiscountCode = DefaultDiscountCode,
                OptionId = OptionId
            },
            new ProductsDiscountsEntity
            {
                ProductCode = ProductId,
                DiscountCode = DefaultDiscountCode1,
                OptionId = OptionId
            },
            new ProductsDiscountsEntity
            {
                ProductCode = ProductId2,
                DiscountCode = DefaultDiscountCode1,
                OptionId = OptionId2
            }
        );
    }
}