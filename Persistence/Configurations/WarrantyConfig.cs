using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class WarrantyConfig: IEntityTypeConfiguration<WarrantyEntity>
{
    private const string WarrantyId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F6";
    
    public void Configure(EntityTypeBuilder<WarrantyEntity> builder)
    {
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Name).HasMaxLength(100);
        builder.HasIndex(w => w.Name);
        builder.Property(w => w.Type);
        builder.Property(w => w.ScopeType);
        builder.Property(w => w.Period).HasMaxLength(70);
        builder.Property(w => w.Description).HasMaxLength(500);
        builder.Property(w => w.Conditions).HasMaxLength(1000);
        builder.Property(w => w.Status).HasMaxLength(50);
        builder.Property(w => w.CreatedAt);
        builder.Property(w => w.CreatedBy).HasMaxLength(50);
        builder.Property(w => w.UpdatedAt);
        builder.Property(w => w.UpdatedBy).HasMaxLength(50);

        builder.HasData( new WarrantyEntity
        {
            Id = Guid.Parse(WarrantyId),
            Name = "Warranty 1",
            Type = WarrantyType.Refund,
            ScopeType = WarrantyScopeType.National,
            Period = "1 year",
            Description = "Warranty 1",
            Conditions = "Warranty 1",
            Status = WarrantyStatusType.Active,
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = "System",
        });
    }
}