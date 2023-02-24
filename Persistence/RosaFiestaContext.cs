using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence;

public sealed class RosaFiestaContext : IdentityDbContext<UserEntity>
{
    public const string DefaultSchema = "RosaFiesta";

    public RosaFiestaContext(DbContextOptions<RosaFiestaContext> options)
        : base(options)
    {
        Products = Set<ProductEntity>();
        Owners = Set<OwnerEntity>();
        Accounts = Set<AccountEntity>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RosaFiestaContext).Assembly);
        modelBuilder.HasDefaultSchema(DefaultSchema);
        
        modelBuilder.Entity<UserEntity>();
        base.OnModelCreating(modelBuilder);
        
    }

    public DbSet<ProductEntity> Products { get; }
    public DbSet<OwnerEntity> Owners { get; set; }
    public DbSet<AccountEntity> Accounts { get; set; }
}
