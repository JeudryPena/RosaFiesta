using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OrderConfiguration: IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable(nameof(OrderEntity));
        builder.HasKey(bill => bill.SKU);
        builder.Property(bill => bill.UserId);
        builder.Property(bill => bill.PayMethodId).IsRequired();
        builder.Property(bill => bill.OrderDate).IsRequired();
        builder.Property(bill => bill.ShippingAddress).IsRequired();
        builder.Property(bill => bill.OrderEmail).IsRequired();
        builder.Property(bill => bill.OrderPhone).IsRequired();
        builder.Property(bill => bill.OrderAddress).IsRequired();
        builder.Property(bill => bill.ShippingCost).IsRequired();
        builder.Property(bill => bill.VoucherNumber).IsRequired();
        builder.Property(bill => bill.VoucherSeries).IsRequired();
        builder.Property(bill => bill.VoucherType).IsRequired();
        builder.Property(bill => bill.OrderStatus).IsRequired();
        builder.Property(bill => bill.TaxesCost).IsRequired();
        builder.HasOne(bill => bill.PayMethod)
            .WithMany(payMethod => payMethod.Orders)
            .HasForeignKey(bill => bill.PayMethodId);
    }
}