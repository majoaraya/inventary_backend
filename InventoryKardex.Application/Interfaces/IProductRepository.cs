// Interfaces define a contract (what a component must do, not how).
// We use them to decouple layers, follow SOLID (Dependency Inversion), and make testing easier.
// Example: the app depends on IProductRepository, and Infrastructure provides the MySQL implementation.

using InventoryKardex.Domain.Entities;

namespace InventoryKardex.Application.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Domain.Entities.Product>> GetAllProductsAsync();
    Task<Domain.Entities.Product?> GetByIdAsync(long id);
    Task<Product?> GetBySkuAsync(string sku);
    Task<Domain.Entities.Product> CreateAsync(Domain.Entities.Product product);

}