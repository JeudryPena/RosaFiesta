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
        builder.Property(bill => bill.SKU).ValueGeneratedOnAdd();
        builder.Property(bill => bill.UserId);
        builder.Property(bill => bill.PayMethodId).IsRequired();
        builder.Property(bill => bill.OrderDate).IsRequired();
        builder.Property(bill => bill.ShippingCost).IsRequired();
        builder.Property(bill => bill.VoucherNumber).IsRequired();
        builder.Property(bill => bill.VoucherSeries).IsRequired();
        builder.Property(bill => bill.VoucherType).IsRequired();
        builder.Property(bill => bill.OrderStatus).IsRequired();
        builder.Property(bill => bill.TaxesCost).IsRequired();
        builder.HasOne(x => x.Address)
            .WithMany()
            .HasForeignKey(x => x.AddressId);
        builder.HasOne(order => order.PayMethod)
            .WithMany()
            .HasForeignKey(order => order.PayMethodId);
        builder.HasMany(order => order.Details)
            .WithOne()
            .HasForeignKey(detail => detail.OrderSku);
    }
}