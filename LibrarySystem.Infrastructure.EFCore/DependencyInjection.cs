using Microsoft.Extensions.DependencyInjection;
using LibrarySystem.Infrastructure.EFCore.DB;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.infrastructure.EFCore;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureEFCore(this IServiceCollection services)
    {
        string? host = Environment.GetEnvironmentVariable("DB_HOST");
        string? dbName = Environment.GetEnvironmentVariable("DB_NAME");
        string? user = Environment.GetEnvironmentVariable("DB_USER");
        string? password = Environment.GetEnvironmentVariable("DB_PASSWORD");
        string? port = Environment.GetEnvironmentVariable("DB_PORT");

        string connectionString = $"Host={host};Port={port};Database={dbName};Username={user};Password={password}";

        services.AddDbContext<DbAppContext>(options => options.UseNpgsql(connectionString));

        return services;
    }
}
