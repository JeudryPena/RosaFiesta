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
		builder.Property(a => a.CreatedAt).IsRequired().ValueGeneratedOnAdd();
		builder.Property(a => a.UpdatedAt).ValueGeneratedOnUpdate();
		builder.HasQueryFilter(b => !b.IsDeleted);
		builder.Property(a => a.Title).IsRequired();
		builder.Property(a => a.City).IsRequired();
		builder.Property(a => a.Country).IsRequired();
		builder.Property(a => a.Street).IsRequired();
		builder.Property(a => a.IsDeleted).IsRequired();
		builder.Property(a => a.ZipCode).IsRequired();
	}
}
