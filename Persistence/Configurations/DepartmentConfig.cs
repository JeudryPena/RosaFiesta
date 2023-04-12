using Domain.Entities.Enterprise;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DepartmentConfig : IEntityTypeConfiguration<DepartmentEntity>
{
    public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
    {
        builder.ToTable("Departments");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Description).HasMaxLength(200);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.CreatedBy);
        builder.Property(x => x.UpdatedBy);
        builder.Property(x => x.Floor);
        builder.HasMany(x => x.Employees).WithOne().HasForeignKey(x => x.DepartmentId);
    }
}