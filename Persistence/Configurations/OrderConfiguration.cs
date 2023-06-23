using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
	public void Configure(EntityTypeBuilder<OrderEntity> builder)
	{
		builder.ToTable(nameof(OrderEntity));
		builder.HasKey(bill => bill.Id);
		builder.Property(bill => bill.Id).ValueGeneratedOnAdd();
		builder.Property(a => a.CreatedAt).IsRequired().ValueGeneratedOnAdd();
		builder.Property(a => a.UpdatedAt).ValueGeneratedOnUpdate();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.Property(bill => bill.UserId);
		builder.Property(bill => bill.PayMethodId).IsRequired();
		builder.Property(bill => bill.OrderDate).IsRequired();
		builder.Property(bill => bill.ShippingCost).IsRequired();
		builder.Property(bill => bill.VoucherNumber).IsRequired();
		builder.Property(bill => bill.VoucherSeries).IsRequired();
		builder.Property(bill => bill.VoucherType).IsRequired();
		builder.Property(bill => bill.TaxesCost).IsRequired();
		builder.Property(a => a.CreatedAt).IsRequired();
		builder.Property(a => a.UpdatedAt);
		builder.Property(a => a.IsDeleted).IsRequired();
		builder.HasOne(x => x.Address)
			.WithMany()
			.HasForeignKey(x => x.AddressId);
		builder.HasOne(order => order.PayMethod)
			.WithMany()
			.HasForeignKey(order => order.PayMethodId);
		builder.HasMany(order => order.Details)
			.WithOne()
			.HasForeignKey(detail => detail.OrderId);
	}
}