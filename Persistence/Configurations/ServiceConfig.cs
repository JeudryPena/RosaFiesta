using Domain.Entities.Enterprise;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ServiceConfig : IEntityTypeConfiguration<ServiceEntity>
{
	public void Configure(EntityTypeBuilder<ServiceEntity> builder)
	{
		builder.HasKey(s => s.Id);
		builder.Property(s => s.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasIndex(s => s.Name).IsUnique();
		builder.HasMany(s => s.QuoteItems).WithOne().HasForeignKey(qi => qi.ServiceId);
	}
}