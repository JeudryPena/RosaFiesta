using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SubCategoryConfig : IEntityTypeConfiguration<SubCategoryEntity>
{
	private const int SubCategory = 1;
	private const int CategoryId = 1;

	public void Configure(EntityTypeBuilder<SubCategoryEntity> builder)
	{
		builder.ToTable(nameof(SubCategoryEntity));
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.Property(x => x.Name).IsRequired();
		builder.HasIndex(x => x.Name).IsUnique();
		builder.Property(x => x.Description).IsRequired();
		builder.Property(x => x.Icon).IsRequired();
		builder.Property(a => a.CreatedAt).IsRequired();
		builder.Property(a => a.UpdatedAt);
		builder.Property(a => a.IsDeleted).IsRequired();
		builder.HasMany(x => x.Products).WithOne().HasForeignKey(x => x.SubCategoryId);
		builder.HasData(new SubCategoryEntity
		{
			Id = SubCategory,
			Name = "Electronics",
			Description = "Electronics",
			Icon = "https://i.imgur.com/0jQYs1R.png",
			CategoryId = CategoryId,
			CreatedAt = DateTime.UtcNow,
			IsDeleted = false,
		});
	}
}