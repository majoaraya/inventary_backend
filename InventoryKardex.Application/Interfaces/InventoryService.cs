// Interfaces define a contract (what a component must do, not how).
// We use them to decouple layers, follow SOLID (Dependency Inversion), and make testing easier.
// Example: the app depends on IProductRepository, and Infrastructure provides the MySQL implementation.

namespace InventoryKardex.Application.Interfaces;

public interface IInventoryService
{
    Task<int> GetStockByProductIdAsync(long productId);
    Task UpdateStockAsync(long productId, int newQuantity);
    Task CreateStockAsync(long productId, int initialQuantity);
    Task<bool> StockExistsAsync(long productId);
    Task<IEnumerable<Domain.Entities.InventoryStock>> GetAllStocksAsync();
    Task DeleteStockAsync(long productId);
    Task<IEnumerable<Domain.Entities.InventoryStock>> GetLowStockProductsAsync(int threshold);
}