using Domain.Entities.Enterprise;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class QuoteItemConfig : IEntityTypeConfiguration<QuoteItemEntity>
{
	public void Configure(EntityTypeBuilder<QuoteItemEntity> builder)
	{
		builder.ToTable(nameof(QuoteItemEntity));
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.Property(a => a.CreatedAt).IsRequired();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.Property(x => x.QuoteId).IsRequired();
		builder.Property(x => x.Price).IsRequired();
		builder.Property(x => x.Quantity).IsRequired();
		builder.Property(x => x.ServiceId).IsRequired();
	}
}