using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SupplierConfig: IEntityTypeConfiguration<SupplierEntity>
{
    private const string SupplierId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F9";
    
    
    public void Configure(EntityTypeBuilder<SupplierEntity> builder)
    {
        builder.ToTable(nameof(SupplierEntity));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Email).HasMaxLength(100);
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Phone).HasMaxLength(20);
        builder.Property(x => x.Address).HasMaxLength(100);
        builder.Property(x => x.IsActive);
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.CreatedBy);
        builder.Property(x => x.UpdatedBy);
        builder.HasData(new SupplierEntity
        {
            Id = Guid.Parse(SupplierId),
            Name = "Supplier 1",
            Email = "suplidor@hotmail.com",
            Phone = "8095395539",
            Address = "La Capital",
            IsActive = true,
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = "System",
            UpdatedAt = DateTimeOffset.UtcNow,
            UpdatedBy = "System",
        });
    }
}