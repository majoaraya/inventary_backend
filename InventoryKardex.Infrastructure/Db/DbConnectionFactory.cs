using System.Data;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace InventoryKardex.Infrastructure.Db;

public class DbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Misiing ConnectionStrings: Default in appsettings.json");
    }

    public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);
}