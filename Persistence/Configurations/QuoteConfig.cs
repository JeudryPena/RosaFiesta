using Domain.Entities.Enterprise;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class QuoteConfig : IEntityTypeConfiguration<QuoteEntity>
{
    public void Configure(EntityTypeBuilder<QuoteEntity> builder)
    {
        builder.HasKey(q => q.Id);
        builder.Property(q => q.Id).ValueGeneratedOnAdd();
        builder.Property(q => q.CustomerName).IsRequired();
        builder.Property(q => q.ContactNumber).IsRequired();
        builder.Property(q => q.EventName).IsRequired();
        builder.Property(q => q.EventDate).IsRequired();
        builder.Property(q => q.CreatedAt).IsRequired();
        builder.Property(q => q.Location).IsRequired();
        builder.HasMany(q => q.QuoteItems).WithOne().HasForeignKey(qi => qi.QuoteId);
    }
}