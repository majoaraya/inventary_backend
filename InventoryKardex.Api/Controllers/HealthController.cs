using InventoryKardex.Infrastructure.Db;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace InventoryKardex.Api.Controllers;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    private readonly DbConnectionFactory _factory;

    public HealthController(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    [HttpGet("db")]
    public async Task<IActionResult> Db()
    {
        await using var conn = (MySqlConnection)_factory.CreateConnection();
        await conn.OpenAsync();

        await using var cmd = new MySqlCommand("SELECT 1;", conn);
        var result = await cmd.ExecuteScalarAsync();

        return Ok(new { status = "ok", db = result });
    }
}
