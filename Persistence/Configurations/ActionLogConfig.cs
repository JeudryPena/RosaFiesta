using Domain.Entities.Security;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ActionLogConfig : IEntityTypeConfiguration<ActionLogEntity>
{
    public void Configure(EntityTypeBuilder<ActionLogEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.ActivityType).IsRequired();
        builder.Property(x => x.UserId);
        builder.Property(x => x.Action).IsRequired();
        builder.Property(x => x.Timestamp).IsRequired();


    }
}