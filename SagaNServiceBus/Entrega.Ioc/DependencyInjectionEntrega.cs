using Entregas.Applications;
using Entregas.Domain.Interfaces;
using Entregas.Infra.Context;
using Entregas.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Entregas.Ioc;

public static class DependencyInjectionEntrega
{
    public static IServiceCollection AddInfrastructureEntrega(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EntregaDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IEntregaRepository, EntregaRepository>();
        services.AddScoped<IEntregaApplicationsServices, EntregaApplicationsServices>();

        return services;
    }
}
