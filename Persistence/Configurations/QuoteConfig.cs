using Domain.Entities.Enterprise;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class QuoteConfig : IEntityTypeConfiguration<QuoteEntity>
{
	public void Configure(EntityTypeBuilder<QuoteEntity> builder)
	{
		builder.HasKey(q => q.Id);
		builder.Property(q => q.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
	}
}