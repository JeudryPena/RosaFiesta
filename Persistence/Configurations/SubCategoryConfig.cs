using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SubCategoryConfig : IEntityTypeConfiguration<SubCategoryEntity>
{

	public void Configure(EntityTypeBuilder<SubCategoryEntity> builder)
	{
		builder.ToTable(nameof(SubCategoryEntity));
		builder.HasKey(x => x.Id);
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.Property(x => x.Name).IsRequired();
		builder.HasIndex(x => x.Name).IsUnique();
		builder.Property(x => x.Description).IsRequired();
		builder.Property(x => x.Icon).IsRequired();
		builder.Property(a => a.IsDeleted).IsRequired();
		builder.HasMany(x => x.Products).WithOne().HasForeignKey(x => x.SubCategoryId);
	}
}