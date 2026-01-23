// Interfaces define a contract (what a component must do, not how).
// We use them to decouple layers, follow SOLID (Dependency Inversion), and make testing easier.
// Example: the app depends on IProductRepository, and Infrastructure provides the MySQL implementation.

namespace InventoryKardex.Application.Interfaces;

public interface IAuthService   
{
    Task<string> AuthenticateAsync(string username, string password);
    Task<bool> ValidateTokenAsync(string token);
    Task<long?> GetUserIdFromTokenAsync(string token);
}