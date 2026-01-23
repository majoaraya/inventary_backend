namespace InventoryKardex.Domain.Entities;

public class InventoryStock
{
    public long ProductId{get;set;}
    public int QtyOnHand{get;set;}
    public DateTime UpdatedAt{get;set;}
}