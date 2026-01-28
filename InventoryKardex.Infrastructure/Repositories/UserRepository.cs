using Dapper;
using InventoryKardex.Infrastructure.Db;

namespace InventoryKardex.Infrastructure.Repositories;

public class UserRepository
{
    private readonly DbConnectionFactory _factory;

    public UserRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<UserRow?> GetByEmailAsync(string email)
    {
        using var conn = _factory.CreateConnection(); // <-- NO await using
        conn.Open();                                  // <-- NO OpenAsync

        const string sql = @"
SELECT u.id, u.email, u.password_hash, u.is_active, r.name AS role_name
FROM users u
JOIN roles r ON r.id = u.role_id
WHERE u.email = @email
LIMIT 1;";

        return await conn.QueryFirstOrDefaultAsync<UserRow>(sql, new { email });
    }
}

public class UserRow
{
    public long id { get; set; }
    public string email { get; set; } = "";
    public string password_hash { get; set; } = "";
    public sbyte is_active { get; set; } // MySQL tinyint(1)
    public string role_name { get; set; } = "";
}
