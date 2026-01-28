using System.Data.Common;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace InventoryKardex.Infrastructure.Db;

public class DbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default")
            ?? throw new InvalidOperationException("Missing ConnectionStrings:Default in appsettings.json");
    }

    public DbConnection CreateConnection() => new MySqlConnection(_connectionString);
}
