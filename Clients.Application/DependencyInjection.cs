using Clients.Application.Commands;
using Clients.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Clients.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IValidator<CreateClientCommand>, CreateClientCommandValidator>();
        services.AddTransient<IValidator<UpdateClientCommand>, UpdateClientCommandValidator>();
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return services;

    } 
}