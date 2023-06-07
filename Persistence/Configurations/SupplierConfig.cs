using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SupplierConfig : IEntityTypeConfiguration<SupplierEntity>
{
    private const string SupplierId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F9";


    public void Configure(EntityTypeBuilder<SupplierEntity> builder)
    {
        builder.ToTable(nameof(SupplierEntity));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Email);
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Phone);
        builder.Property(x => x.Address);
        builder.Property(a => a.CreatedAt).IsRequired();
        builder.Property(a => a.UpdatedAt);
        builder.Property(a => a.IsDeleted).IsRequired();
        builder.HasData(new SupplierEntity
        {
            Id = Guid.Parse(SupplierId),
            Name = "Supplier 1",
            Email = "suplidor@hotmail.com",
            Phone = "8095395539",
            Address = "La Capital",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false
        });
    }
}