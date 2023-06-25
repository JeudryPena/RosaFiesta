using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PayMethodConfiguration : IEntityTypeConfiguration<PayMethodEntity>
{
	public void Configure(EntityTypeBuilder<PayMethodEntity> builder)
	{
		builder.ToTable(nameof(PayMethodEntity));
		builder.HasKey(e => e.Id);
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.Property(e => e.Id).ValueGeneratedOnAdd();
		builder.Property(e => e.Name).IsRequired();
		builder.Property(e => e.Description).IsRequired();
		builder.Property(a => a.CreatedAt).IsRequired();
		builder.Property(a => a.UpdatedAt);
		builder.Property(a => a.IsDeleted).IsRequired();
		builder.Property(e => e.PayMethodType).IsRequired();
	}
}