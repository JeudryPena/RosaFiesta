using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SupplierConfig : IEntityTypeConfiguration<SupplierEntity>
{
	public void Configure(EntityTypeBuilder<SupplierEntity> builder)
	{
		builder.ToTable(nameof(SupplierEntity));
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Name).IsRequired();
		builder.HasIndex(x => x.Name).IsUnique();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.Property(x => x.Email);
		builder.HasIndex(x => x.Email).IsUnique();
		builder.Property(x => x.Phone);
		builder.HasIndex(x => x.Phone).IsUnique();
		builder.Property(x => x.Address);
		builder.Property(a => a.CreatedAt).IsRequired();
		builder.Property(a => a.UpdatedAt);
		builder.Property(a => a.IsDeleted).IsRequired();
	}
}