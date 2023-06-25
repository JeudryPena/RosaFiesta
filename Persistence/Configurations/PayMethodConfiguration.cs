using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PayMethodConfiguration : IEntityTypeConfiguration<PayMethodEntity>
{
	public void Configure(EntityTypeBuilder<PayMethodEntity> builder)
	{
		builder.HasKey(e => e.Id);
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.Property(e => e.Id).ValueGeneratedOnAdd();
	}
}