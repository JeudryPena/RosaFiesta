using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SubCategoryConfig : IEntityTypeConfiguration<SubCategoryEntity>
{
	public void Configure(EntityTypeBuilder<SubCategoryEntity> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.HasIndex(x => x.Name).IsUnique();
		builder.HasMany(x => x.Products).WithOne(x => x.SubCategory).HasForeignKey(x => x.SubCategoryId);
	}
}