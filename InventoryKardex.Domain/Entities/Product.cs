namespace InventoryKardex.Domain.Entities;

public class Product
{
    public long Id{get;set;}
    public string Sku{get;set;}=string.Empty;
    public string Name{get;set;}=string.Empty;
    public string? Description{get;set;}=string.Empty;
    public string Unit {get;set;}=string.Empty;
    public decimal Cost{get;set;}
    public decimal Price{get;set;}
    public bool IsActive{get;set;}
    public int LowStockThreshold{get;set;}
    public DateTime CreatedAt{get;set;}
    public DateTime UpdatedAt{get;set;}

}