using Domain.Entities.Enterprise;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ServiceConfig : IEntityTypeConfiguration<ServiceEntity>
{
    public void Configure(EntityTypeBuilder<ServiceEntity> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired();
        builder.HasIndex(s => s.Name).IsUnique();
        builder.Property(s => s.Description).IsRequired();
        builder.Property(s => s.Price).IsRequired();
        builder.Property(s => s.Image).IsRequired();
        builder.Property(s => s.Quantity).IsRequired();
        builder.Property(s => s.QuantityAvaliable).IsRequired();
        builder.Property(a => a.CreatedAt).IsRequired();
        builder.Property(a => a.UpdatedAt);
        builder.Property(a => a.IsDeleted).IsRequired();
        builder.HasMany(s => s.QuoteItems).WithOne().HasForeignKey(qi => qi.ServiceId);
    }
}