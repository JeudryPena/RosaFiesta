using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ProductsDiscountsConfig : IEntityTypeConfiguration<ProductsDiscountsEntity>
{
    private const string DefaultDiscountCode = "ROSA";
    private const string DefaultDiscountCode1 = "WELCOME";
    private const string ProductId = "SDA01";
    private const string ProductId2 = "SDA02";
    private const int OptionId = 1;
    private const int OptionId2 = 2;
    private const int OptionId3 = 3;
    private const string ProductDiscountId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f4";
    private const string ProductDiscountId2 = "b22698b8-42a2-4115-9631-1c2d1e2ac5f5";
    private const string ProductDiscountId3 = "b22698b8-42a2-4115-9631-1c2d1e2ac5f6";
    public void Configure(EntityTypeBuilder<ProductsDiscountsEntity> builder)
    {
        builder.ToTable(nameof(ProductsDiscountsEntity));
        builder.HasKey(x => new { x.Id, x.DiscountCode });
        builder.HasOne(x => x.Option).WithMany(x => x.ProductsDiscounts).HasForeignKey(x => x.OptionId);
        builder.HasData(
            new ProductsDiscountsEntity
            {
                Id = Guid.Parse(ProductDiscountId),
                ProductId = ProductId,
                DiscountCode = DefaultDiscountCode,
                OptionId = OptionId
            },
            new ProductsDiscountsEntity
            {
                Id = Guid.Parse(ProductDiscountId2),
                ProductId = ProductId,
                DiscountCode = DefaultDiscountCode1,
                OptionId = OptionId2
            },
            new ProductsDiscountsEntity
            {
                Id = Guid.Parse(ProductDiscountId3),
                ProductId = ProductId2,
                DiscountCode = DefaultDiscountCode1,
                OptionId = OptionId3
            }
        );
    }
}