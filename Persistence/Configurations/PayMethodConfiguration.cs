using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PayMethodConfiguration: IEntityTypeConfiguration<PayMethodEntity>
{
    public void Configure(EntityTypeBuilder<PayMethodEntity> builder)
    {
        builder.ToTable(nameof(PayMethodEntity));
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
        
    }
}