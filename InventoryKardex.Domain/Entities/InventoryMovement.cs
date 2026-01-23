using InventoryKardex.Domain.Enum;

namespace InventoryKardex.Domain.Entities;

public class InventoryMovement
{
    public long Id{get;set;}
    public long ProductId{get;set;}
    public MovementType MovementType{get;set;}
    public int Qty{get;set;}
    public string? Reason{get;set;}=string.Empty;
    public long CreatedBy{get;set;}
    public DateTime CreatedAt{get;set;}
    public int StockBefore{get;set;}
    public int StockAfter{get;set;}
}