using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class WarrantyConfig : IEntityTypeConfiguration<WarrantyEntity>
{
	public void Configure(EntityTypeBuilder<WarrantyEntity> builder)
	{
		builder.HasKey(w => w.Id);
		builder.Property(w => w.Name);
		builder.HasIndex(w => w.Name);
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.Property(w => w.Type);
		builder.Property(w => w.Period);
		builder.Property(w => w.Description);
		builder.Property(w => w.Conditions);
		builder.Property(w => w.Status);
		builder.Property(a => a.CreatedAt).IsRequired();
		builder.Property(a => a.UpdatedAt);
		builder.Property(a => a.IsDeleted).IsRequired();
	}
}