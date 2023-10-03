using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pagamentos.Applications;
using Pagamentos.Domain.Interfaces;
using Pagamentos.Infra.Context;
using Pagamentos.Infra.Repositories;

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
