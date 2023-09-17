using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySqlConnector;

using Common.EFCore.Models;

namespace Common.EFCore;

public static class LibraryContextExtension
{
    public static IServiceCollection AddLibraryContext(this IServiceCollection services)
    {
        const string connectionString = "server=localhost;user=root;password=Adr!an12003;database=Library";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
        services.AddDbContext<LibraryContext>(options => options
            .UseMySql(connectionString, serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
        );
        return services;
    }
}