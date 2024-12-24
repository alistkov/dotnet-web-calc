using Calculator.Application.Base;
using Calculator.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IOperationFactory, OperationDecorator>();
        return services;
    }
}