using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SupplierConfig : IEntityTypeConfiguration<SupplierEntity>
{
	public void Configure(EntityTypeBuilder<SupplierEntity> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasIndex(x => x.Name).IsUnique();
		builder.HasQueryFilter(a => !a.IsDeleted);
	}
}