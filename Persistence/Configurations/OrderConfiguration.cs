using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OrderConfiguration: IEntityTypeConfiguration<OrderEntity>
{
    private const int OrderSkuDefault = 1;
    private const string AdminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
    private const string PayMethodId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F4";
    
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable(nameof(OrderEntity));
        builder.HasKey(bill => bill.SKU);
        builder.Property(bill => bill.UserId);
        builder.Property(bill => bill.PayMethodId).IsRequired();
        builder.Property(bill => bill.PaymentDate).IsRequired();
        builder.Property(bill => bill.ShippingAddress).IsRequired();
        builder.Property(bill => bill.OrderEmail).IsRequired();
        builder.Property(bill => bill.OrderPhone).IsRequired();
        builder.Property(bill => bill.OrderAddress).IsRequired();
        builder.Property(bill => bill.AmmountPaid).IsRequired();
        builder.Property(bill => bill.ShippingCost).IsRequired();
        builder.Property(bill => bill.VoucherNumber).IsRequired();
        builder.Property(bill => bill.VoucherSeries).IsRequired();
        builder.Property(bill => bill.VoucherType).IsRequired();
        builder.Property(bill => bill.OrderStatus).IsRequired();
        builder.HasOne(bill => bill.PayMethod)
            .WithMany(payMethod => payMethod.Orders)
            .HasForeignKey(bill => bill.PayMethodId);

        builder.HasData( new OrderEntity
        {
            SKU = OrderSkuDefault,
            UserId = AdminId,
            PayMethodId = Guid.Parse(PayMethodId),
            PaymentDate = DateTime.Now,
            ShippingAddress = "1",
            OrderEmail = "1",
            OrderPhone = "1",
            OrderAddress = "1",
            AmmountPaid = 1,
            ShippingCost = 1,
            VoucherNumber = 1,
            VoucherSeries = "1",
            VoucherType = VoucherType.Bills,
            OrderStatus = OrderStatusType.Paid,
        });
    }
}