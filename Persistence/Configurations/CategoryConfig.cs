using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CategoryConfig : IEntityTypeConfiguration<CategoryEntity>
{

	public void Configure(EntityTypeBuilder<CategoryEntity> builder)
	{
		builder.ToTable(nameof(CategoryEntity));
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(x => !x.IsDeleted);
		builder.Property(x => x.Name).IsRequired();
		builder.HasIndex(x => x.Name).IsUnique();
		builder.Property(x => x.Description).IsRequired();
		builder.Property(x => x.Icon).IsRequired();
		builder.Property(a => a.CreatedBy).IsRequired();
		builder.Property(a => a.UpdatedBy);
		builder.Property(a => a.IsDeleted).IsRequired();
		builder.HasMany(x => x.SubCategories).WithOne().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
	}
}