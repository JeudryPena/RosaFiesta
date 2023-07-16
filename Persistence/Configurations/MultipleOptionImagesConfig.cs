using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class MultipleOptionImagesConfig : IEntityTypeConfiguration<MultipleOptionImagesEntity>
{
	public void Configure(EntityTypeBuilder<MultipleOptionImagesEntity> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();

	}
}