using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class AccountConfiguration: IEntityTypeConfiguration<AccountEntity> 
{
    public void Configure(EntityTypeBuilder<AccountEntity> builder)
    {
        builder.ToTable(nameof(AccountEntity));
        builder.HasKey(account => account.Id);
        builder.Property(account => account.Id).ValueGeneratedOnAdd();
        builder.Property(account => account.AccountType).HasMaxLength(50);
        builder.Property(account => account.DateCreated).IsRequired();
    }
}
