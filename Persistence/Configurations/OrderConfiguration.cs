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