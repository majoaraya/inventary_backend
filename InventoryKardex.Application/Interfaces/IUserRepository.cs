// Interfaces define a contract (what a component must do, not how).
// We use them to decouple layers, follow SOLID (Dependency Inversion), and make testing easier.
// Example: the app depends on IProductRepository, and Infrastructure provides the MySQL implementation.

namespace InventoryKardex.Application.Interfaces;

public interface IUserRepository
{
    Task<Domain.Entities.User?> GetByUsernameAsync(string username);
    Task<Domain.Entities.User> CreateAsync(Domain.Entities.User user);
    Task<Domain.Entities.User?> GetByIdAsync(long id);
    Task<IEnumerable<Domain.Entities.User>> GetAllUsersAsync();
    Task DeleteAsync(long id);
    Task UpdateAsync(Domain.Entities.User user);
    Task<bool> UserExistsAsync(string username);
}