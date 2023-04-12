using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class MultipleOptionImagesConfig: IEntityTypeConfiguration<MultipleOptionImages>
{
    public void Configure(EntityTypeBuilder<MultipleOptionImages> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Image).IsRequired();
        builder.Property(x => x.OptionId).IsRequired();
    }
}