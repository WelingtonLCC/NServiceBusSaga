using Microsoft.EntityFrameworkCore;

namespace Entregas.Infra.Context;

public class EntregaDbContext : DbContext
{
    public EntregaDbContext(DbContextOptions<EntregaDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntregaDbContext).Assembly);
    }
}
