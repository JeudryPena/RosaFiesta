using Domain.Entities.Security;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AddressConfig : IEntityTypeConfiguration<AddressEntity>
{
    private const string UserId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.Title).IsRequired();
        builder.Property(a => a.City).IsRequired();
        builder.Property(a => a.Country).IsRequired();
        builder.Property(a => a.Street).IsRequired();
        builder.Property(a => a.CreatedAt).IsRequired();
        builder.Property(a => a.UpdatedAt);
        builder.Property(a => a.IsDeleted).IsRequired();
        builder.Property(a => a.ZipCode).IsRequired();
    }
}
