using Evently.Modules.Events.Api.Database;
using Evently.Modules.Events.Api.Events;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Modules.Events.Api;
public static class EventModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateEvent.MapEndpoint(app);
        GetEvent.MapEndpoint(app);
    }

    public static IServiceCollection AddEvenstModules(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        string connectionString =
            configuration.GetConnectionString("Database");

        Console.WriteLine(connectionString);

        services.AddDbContext<EventsDbContext>(options =>
            options
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());

        return services;
    }
}
