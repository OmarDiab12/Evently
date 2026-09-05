using System.Data.Common;
using Evently.Modules.Events.Application.Abstractions.Data;
using Npgsql;

namespace Evently.Modules.Events.Infrastructure.Data;

public sealed class DbConnectionFactory(NpgsqlDataSource npgsql) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await npgsql.OpenConnectionAsync();
    }
}
