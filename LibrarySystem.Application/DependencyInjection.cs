using Microsoft.Extensions.DependencyInjection;
using MediatR;
using LibrarySystem.Application.Commands;

namespace LibrarySystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services){

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddBookCommand).Assembly));

        return services;
    }

}
