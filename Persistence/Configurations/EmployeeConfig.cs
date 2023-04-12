using Domain.Entities.Enterprise;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class EmployeeConfig : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Email).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(15);
        builder.HasIndex(x => x.Phone).IsUnique();
        builder.Property(x => x.DepartmentId).IsRequired();
        builder.Property(x => x.JobTitle).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Address).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Salary).IsRequired();
        builder.Property(x => x.WorkingHours).IsRequired().HasMaxLength(50);
        builder.Property(x => x.WorkingDays).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Resume);
        builder.Property(x => x.Photo).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.CreatedBy);
        builder.Property(x => x.UpdatedBy);
        builder.Property(x => x.IdentityCard).IsRequired();
        builder.HasIndex(x => x.IdentityCard).IsUnique();
    }
}