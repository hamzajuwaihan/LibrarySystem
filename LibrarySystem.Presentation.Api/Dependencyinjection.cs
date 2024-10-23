using LibrarySystem.Presentation.Api.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
namespace LibrarySystem.Presentation.Api;

public static class Dependencyinjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services){
        services.AddValidatorsFromAssemblyContaining<AddBookCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateBookCommandValidator>();


        return services;
    }
}
