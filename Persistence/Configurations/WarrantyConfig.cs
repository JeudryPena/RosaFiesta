using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class WarrantyConfig : IEntityTypeConfiguration<WarrantyEntity>
{
    private const string WarrantyId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F6";

    public void Configure(EntityTypeBuilder<WarrantyEntity> builder)
    {
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Name);
        builder.HasIndex(w => w.Name);
        builder.Property(w => w.Type);
        builder.Property(w => w.ScopeType);
        builder.Property(w => w.Period);
        builder.Property(w => w.Description);
        builder.Property(w => w.Conditions);
        builder.Property(w => w.Status);
        builder.Property(a => a.CreatedAt).IsRequired();
        builder.Property(a => a.UpdatedAt);
        builder.Property(a => a.IsDeleted).IsRequired();
        builder.Property(a => a.CreatedAt).IsRequired();
        builder.Property(a => a.UpdatedAt);
        builder.Property(a => a.IsDeleted).IsRequired();
        builder.HasData(new WarrantyEntity
        {
            Id = Guid.Parse(WarrantyId),
            Name = "Warranty 1",
            Type = WarrantyType.Refund,
            ScopeType = WarrantyScopeType.National,
            Period = "1 year",
            Description = "Warranty 1",
            Conditions = "Warranty 1",
            Status = WarrantyStatusType.Active,
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false
        });
    }
}