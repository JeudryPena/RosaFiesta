using Domain.Entities.Enterprise;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class QuoteItemConfig : IEntityTypeConfiguration<QuoteItemEntity>
{
	public void Configure(EntityTypeBuilder<QuoteItemEntity> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
	}
}