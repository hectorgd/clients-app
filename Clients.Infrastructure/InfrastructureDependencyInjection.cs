using Clients.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clients.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ClientsDataContext>(options =>
        {
            options.UseInMemoryDatabase("ClientsDb");
        });

        services.AddScoped<IClientsRepository, ClientsRepository>();
    }
}