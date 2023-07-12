using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CategoryConfig : IEntityTypeConfiguration<CategoryEntity>
{

	public void Configure(EntityTypeBuilder<CategoryEntity> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(x => !x.IsDeleted);
		builder.HasIndex(x => x.Name).IsUnique();
	}
}