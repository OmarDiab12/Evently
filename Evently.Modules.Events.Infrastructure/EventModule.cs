using Evently.Modules.Events.Application;
using Evently.Modules.Events.Application.Abstractions.Data;
using Evently.Modules.Events.Domain.Events;
using Evently.Modules.Events.Infrastructure.Data;
using Evently.Modules.Events.Infrastructure.Database;
using Evently.Modules.Events.Infrastructure.Events;
using Evently.Modules.Events.Presentation.Events;
using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace Evently.Modules.Events.Infrastructure;
public static class EventModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        EventEndPoints.MapEndoints(app);
    }

    public static IServiceCollection AddEventsModules(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(AssemplyReference.assembly);
        });

        services.AddValidatorsFromAssembly(AssemplyReference.assembly, includeInternalTypes: true);

        services.AddInfrastructure(configuration);
        return services;
    }

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database");

        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(connectionString).Build();

        services.TryAddSingleton(npgsqlDataSource);

        services.AddDbContext<EventsDbContext>(options =>
            options
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IUnitOfWork>(s => s.GetRequiredService<EventsDbContext>());
    }
}
