using Domain.Entities.Security;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AddressConfig : IEntityTypeConfiguration<AddressEntity>
{
	public void Configure(EntityTypeBuilder<AddressEntity> builder)
	{
		builder.HasKey(a => a.Id);
		builder.Property(a => a.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(b => !b.IsDeleted);
	}
}
