using LibrarySystem.infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using LibrarySystem.infrastructure.EFCore;

namespace LibrarySystem.infrastructure;

public static class Dependencyinjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services){

        services.AddInfrastructureEFCore();

        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}
