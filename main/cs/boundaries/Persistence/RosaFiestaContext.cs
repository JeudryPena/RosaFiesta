using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Persistence;

public class RosaFiestaContext : DbContext
{
    public const string DefaultSchema = "RosaFiesta";

    // Aqui se declara tabla
    public RosaFiestaContext(DbContextOptions<RosaFiestaContext> options)
        : base(options)
    {
        Users = Set<UserEntity>();
        Products = Set<ProductModel>();
    }

    // Se va a declarar relaciones de tablas
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder, nameof(modelBuilder));
        modelBuilder.HasDefaultSchema(DefaultSchema);
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseIdentityColumns();
    }

    public DbSet<UserEntity> Users { get; }
    public DbSet<ProductModel> Products { get; }
}
