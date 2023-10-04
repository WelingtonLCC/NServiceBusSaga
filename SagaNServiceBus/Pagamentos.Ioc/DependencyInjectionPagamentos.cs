namespace Pagamentos.Ioc;

public static class DependencyInjectionPagamentos
{
    public static IServiceCollection AddInfrastructurePay(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PaymentDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IPagamentoApplicationServices, PagamentoApplicationServices>();
        services.AddScoped<IPagamentoRepository, PagamentoRepository>();
        
        return services;
    }
}
