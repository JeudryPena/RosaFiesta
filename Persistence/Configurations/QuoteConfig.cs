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
		builder.Property(a => a.CreatedAt).IsRequired().ValueGeneratedOnAdd();
		builder.Property(a => a.UpdatedAt).ValueGeneratedOnUpdate();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.Property(q => q.CustomerName).IsRequired();
		builder.Property(q => q.ContactNumber).IsRequired();
		builder.Property(q => q.EventName).IsRequired();
		builder.Property(q => q.EventDate).IsRequired();
		builder.Property(a => a.CreatedAt).IsRequired();
		builder.Property(a => a.UpdatedAt);
		builder.Property(a => a.IsDeleted).IsRequired();
		builder.Property(q => q.Location).IsRequired();
		builder.HasMany(q => q.QuoteItems).WithOne().HasForeignKey(qi => qi.QuoteId);
	}
}