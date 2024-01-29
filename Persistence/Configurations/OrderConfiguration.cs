using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
	public void Configure(EntityTypeBuilder<OrderEntity> builder)
	{
		builder.HasKey(bill => bill.Id);
		builder.Property(bill => bill.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasMany(order => order.Details)
			.WithOne(x => x.Order)
			.HasForeignKey(detail => detail.OrderId);
		builder.HasOne(order => order.Address)
			.WithOne()
			.HasForeignKey<OrderEntity>(order => order.AddressId);
		builder.HasOne(order => order.Quote)
			.WithOne(x => x.Order)
			.HasForeignKey<OrderEntity>(order => order.QuoteId);
	}
}