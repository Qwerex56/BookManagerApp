using LibrarySimService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarySimService;

public static class LibrarySimServiceExtension
{
    public static IServiceCollection AddLibrarySimServices(this IServiceCollection services)
    {
        services.AddScoped<BookService>();

        return services;
    }
}