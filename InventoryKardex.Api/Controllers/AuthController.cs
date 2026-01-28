using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using InventoryKardex.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InventoryKardex.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserRepository _users;
    private readonly IConfiguration _config;

    public AuthController(UserRepository users, IConfiguration config)
    {
        _users = users;
        _config = config;
    }

    public record LoginRequest(string Email, string Password);

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest req)
    {
        var user = await _users.GetByEmailAsync(req.Email);

        if (user is null || user.is_active == 0)
            return Unauthorized(new { message = "Invalid credentials" });

        var ok = BCrypt.Net.BCrypt.Verify(req.Password, user.password_hash);
        if (!ok)
            return Unauthorized(new { message = "Invalid credentials" });

        var token = CreateJwt(user.id, user.email, user.role_name);

        return Ok(new
        {
            token,
            user = new { id = user.id, email = user.email, role = user.role_name }
        });
    }

    private string CreateJwt(long userId, string email, string role)
    {
        var key = _config["Jwt:Key"]!;
        var issuer = _config["Jwt:Issuer"]!;
        var audience = _config["Jwt:Audience"]!;
        var hours = int.TryParse(_config["Jwt:ExpiresHours"], out var h) ? h : 8;

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(ClaimTypes.Role, role)
        };

        var creds = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            SecurityAlgorithms.HmacSha256
        );

        var jwt = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(hours),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
