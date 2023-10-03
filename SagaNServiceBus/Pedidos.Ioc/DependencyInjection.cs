namespace Pedidos.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IPedidosApplicationServices, PedidosApplicationServices>();
        services.AddScoped<IPedidosRepository, PedidosRepository>();

        return services;
    }
}
