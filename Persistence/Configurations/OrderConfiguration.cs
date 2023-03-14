using Domain.Entities.Product;
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
        builder.Property(bill => bill.PaymentDate).IsRequired();
        builder.Property(bill => bill.ShippingAddress).IsRequired();
        builder.Property(bill => bill.AmmountPaid).IsRequired();
        builder.Property(bill => bill.OrderEmail).IsRequired();
        builder.Property(bill => bill.OrderPhone).IsRequired();
        builder.Property(bill => bill.OrderAddress).IsRequired();
        builder.Property(bill => bill.ShippingCost).IsRequired();
        builder.Property(bill => bill.VoucherNumber).IsRequired();
        builder.Property(bill => bill.VoucherSeries).IsRequired();
        builder.Property(bill => bill.VoucherType).IsRequired();
        builder.Property(bill => bill.OrderStatus).IsRequired();
        builder.HasOne(bill => bill.User)
            .WithMany(user => user.Bills)
            .HasForeignKey(bill => bill.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(bill => bill.PayMethod)
            .WithMany(payMethod => payMethod.Bills)
            .HasForeignKey(bill => bill.PayMethodId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}