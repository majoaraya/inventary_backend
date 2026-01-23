// DTOs (Data Transfer Objects) are simple classes used to move data between layers (API, services, frontend).
// They help control what data is sent/received (e.g., never expose password_hash) and keep the API stable
// even if internal entities or database tables change.

namespace InventoryKardex.Application.DTOs;

public record ProductResponse
{
    long Id;
    string Sku;
    string Name;
    string? Description;
    string Unit;
    decimal Cost;
    decimal Price;
    bool IsActive;
    int LowStockThreshold;

}