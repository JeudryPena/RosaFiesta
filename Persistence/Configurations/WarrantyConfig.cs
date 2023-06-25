using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class WarrantyConfig : IEntityTypeConfiguration<WarrantyEntity>
{
	public void Configure(EntityTypeBuilder<WarrantyEntity> builder)
	{
		builder.HasKey(w => w.Id);
		builder.HasIndex(w => w.Name);
		builder.HasQueryFilter(a => !a.IsDeleted);
	}
}