using System.Data;
using NetCoreTemplate.Application.Abstractions.Data;
using Npgsql;

namespace NetCoreTemplate.Infrastructure.Data;

internal sealed class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        return connection;
    }
}