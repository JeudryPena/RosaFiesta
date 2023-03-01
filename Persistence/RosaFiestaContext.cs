using Domain.Entities;
using Domain.Entities.Product;
using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

public sealed class RosaFiestaContext : IdentityDbContext<UserEntity>
{
    public const string DefaultSchema = "RosaFiesta";

    public RosaFiestaContext(DbContextOptions<RosaFiestaContext> options)
        : base(options)
    {
        Products = Set<ProductEntity>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RosaFiestaContext).Assembly);
        modelBuilder.HasDefaultSchema(DefaultSchema);
        modelBuilder.Entity<UserEntity>();
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ProductEntity> Products { get; }
}
