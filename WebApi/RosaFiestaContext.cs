using Microsoft.EntityFrameworkCore;

namespace WebApi;

public class RosaFiestaContext : DbContext
{
    // Aqui se declara tabla
    public RosaFiestaContext(DbContextOptions<RosaFiestaContext> options) : base(options)
    {
        User = Set<UserModel>();
    }

    // Se va a declarar relaciones de tablas 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder, nameof(modelBuilder));
        modelBuilder.HasDefaultSchema("rosafiesta");
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseIdentityColumns();
    }

    public DbSet<UserModel> User { get; }
}