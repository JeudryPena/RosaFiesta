using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<DiscountEntity>
{
    public void Configure(EntityTypeBuilder<DiscountEntity> builder)
    {
        builder.ToTable(nameof(DiscountEntity));
        builder.HasKey(x => x.DiscountCode);
        builder.Property(x => x.DiscountName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.DiscountType).IsRequired();
        builder.Property(x => x.DiscountImage);
        builder.Property(x => x.DiscountCodeImage).HasMaxLength(10);
        builder.Property(x => x.DiscountDescription).HasMaxLength(100);
        builder.Property(x => x.Discount).IsRequired();
        builder.Property(x => x.DiscountStartDate).IsRequired();
        builder.Property(x => x.DiscountEndDate).IsRequired();
        
    }
}