using Microsoft.EntityFrameworkCore;

namespace Pedidos.Infra.Context;

public class ApplicationsDbContext : DbContext
{
    public ApplicationsDbContext(DbContextOptions<ApplicationsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationsDbContext).Assembly);
    }
}
